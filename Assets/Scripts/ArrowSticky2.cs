using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSticky2 : MonoBehaviour
{
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //player a yapýþacak
            // rb.velocity = Vector2.zero;
            //rb.isKinematic = true;
            gameObject.transform.parent = GameObject.Find("StickyArrow").transform;
        }
        else if (collision.CompareTag("ArrowPlayer") || collision.CompareTag("Enemy"))
        {

        }
        //else if (collision.CompareTag("OutofCity")){Destroy(gameObject,0.2f);}
        else
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true; //stop physic
        }
    }
}
