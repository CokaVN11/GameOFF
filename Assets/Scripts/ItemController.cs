using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public int point;
    public int weight;
    public float speed;

    private Rigidbody2D rb;


    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, -1 * speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("EndPlatform"))
        {
            Destroy(gameObject);
        }
    }
}
