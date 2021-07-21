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
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //enemye yapýþacak
            //rb.velocity = new Vector2(0, 0);
            //rb.isKinematic = true; //stop physic
           
        }
        else if (collision.CompareTag("Arrow") || collision.CompareTag("Player"))
        {

        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            rb.isKinematic = true; //stop physic
            Destroy(gameObject, 5);
        }
    }
}
