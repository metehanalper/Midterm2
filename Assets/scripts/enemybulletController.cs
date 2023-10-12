using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybulletController : MonoBehaviour
{
    float speed;
    bool isready;
    Vector2 direction;
    // Start is called before the first frame update
    private void Awake()
    {
        speed = 5f;
        isready = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isready)
        {
            Vector2 pos = transform.position;
            pos += direction * speed * Time.deltaTime;
            transform.position = pos;

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            if (pos.x < min.x || pos.x > max.x || pos.y < min.y || pos.y > max.y)
            {
                Destroy(gameObject);
            }
        }
    }
    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        isready = true;
    }
}
