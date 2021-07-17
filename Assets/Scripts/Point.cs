using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public Camera cam;
    Rigidbody2D rigidBody;
    Vector2 mousePosition;
    Vector2 lookDirection;
    float angle;

    
    private void Start()
    {
        //Cursor.visible = false;
        rigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        mousePosition =  cam.ScreenToWorldPoint(Input.mousePosition); // bu kod ile mousumuzun noktas�n� biliyoruz art�k
        lookDirection = mousePosition - rigidBody.position;   // vect�r�n x ve y uzunluklar�n� buluyoruz
        angle = Mathf.Atan2(lookDirection.y,lookDirection.x) * Mathf.Rad2Deg -90f; // vect�r hesaplamas� ile a��dan y�n�n� bulduk (tan(y/x veya b/a))
        rigidBody.rotation = angle;
    }
   
}
