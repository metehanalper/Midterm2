using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyshipcontroller : MonoBehaviour
{
    
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos = new Vector2(pos.x - speed * Time.deltaTime, pos.y);
        transform.position = pos;
        

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.x < min.x)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        Destroy(gameObject);
        playerController.score++;
    }

    
}
