using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public float _SpeedNormal;
    public float _SpeedFast;
    public float _SpeedSlow;

    Vector2 movement;
    public Rigidbody2D rigidBody;
    private void Start()
    {
        
    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * _SpeedNormal * Time.fixedDeltaTime);
    }
}
