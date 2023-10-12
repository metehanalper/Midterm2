using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemygunController : MonoBehaviour
{
    public GameObject enemybulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireEnemyBullet",2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FireEnemyBullet()
    {
       
       
        GameObject playership = GameObject.Find("player");
        if (playership != null)
        {
            GameObject bullet = (GameObject) Instantiate(enemybulletPrefab);
            bullet.transform.position = transform.position;
            Vector2 direction = playership.transform.position - transform.position;
            bullet.GetComponent<enemybulletController>().SetDirection(direction);
        }
    }
}
