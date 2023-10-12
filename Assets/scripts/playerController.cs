using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public GameObject spawner;
    public GameObject panel;
    public float timer;
    public Text time;
    public Text sText;
    public static int score;
    public float speed;
    public GameObject playerbulletPrefab;

    public GameObject leftgun;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        time.text = "Time: " + timer;
        if (timer > 60 || score>=20)
        {
            panel.SetActive(true);
            Destroy(gameObject);
            Destroy(spawner);
        }
        if (Input.GetKeyDown("space"))
        {
            
            GameObject bullet1 = (GameObject) Instantiate(playerbulletPrefab);
            bullet1.transform.position = leftgun.transform.position;
            
            
        }
        
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(x, y).normalized;
        Move(direction);
        
        sText.text = "Score: " + playerController.score.ToString();
    }
    void Move(Vector2 dir)
    {
        Vector2 pos = transform.position;
        pos += dir * speed * Time.deltaTime;
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;
        max.y = max.y - 0.285f;
        min.y = min.y + 0.285f;
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);
        transform.position = pos;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemyship")
        {
            Destroy(gameObject);
        }
    }
}
