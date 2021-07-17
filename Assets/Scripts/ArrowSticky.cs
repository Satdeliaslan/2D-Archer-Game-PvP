using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSticky : MonoBehaviour
{
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
     
    }
   
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }
    }
}
