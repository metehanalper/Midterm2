using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBulletControl : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos = new Vector2(pos.x + speed * Time.deltaTime, pos.y);
        transform.position = pos;
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if (transform.position.x > max.x)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }

    
}
