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

    //health bar system
    [SerializeField] HealthSystem healthBar;
    [SerializeField] float hitPoints;
    [SerializeField] float maxHitPoints = 8;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        hitPoints = maxHitPoints;
        healthBar.SetHealth(hitPoints, maxHitPoints);
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
    private void takeHit(float damage)
    {
        hitPoints -= damage;
        healthBar.SetHealth(hitPoints, maxHitPoints);
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow"))
        {
            takeHit(1);

        }
    }
}
