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
        mousePosition =  cam.ScreenToWorldPoint(Input.mousePosition); // bu kod ile mousumuzun noktasýný biliyoruz artýk
        lookDirection = mousePosition - rigidBody.position;   // vectörün x ve y uzunluklarýný buluyoruz
        angle = Mathf.Atan2(lookDirection.y,lookDirection.x) * Mathf.Rad2Deg -90f; // vectör hesaplamasý ile açýdan yönünü bulduk (tan(y/x veya b/a))
        rigidBody.rotation = angle;
    }
   
}
