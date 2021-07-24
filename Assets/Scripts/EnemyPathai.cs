using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyPathai : MonoBehaviour
{
    public GameObject player;
    [SerializeField] float range;
    [SerializeField] float shootRange;
    [SerializeField] float runAndShootRange;
    [SerializeField] float stabRange;
    Rigidbody2D rb;

    AIPath aipath;

    public GameObject arrowPrefab;
    public GameObject arrowParent;

    public float shootRate = 1f;
    private float nextShootTime;

    public GameObject raycastPoint;
    private bool firstStart;

    //health bar system
    [SerializeField] HealthSystem healthBar;
    [SerializeField] float hitPoints;
    [SerializeField] float maxHitPoints = 5;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aipath = GetComponent<AIPath>();
        hitPoints = maxHitPoints;
        healthBar.SetHealth(hitPoints, maxHitPoints);

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
    private void FixedUpdate()
    {

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < range)
        {
            float angle = Mathf.Atan2(transform.position.y - player.transform.position.y, transform.position.x - player.transform.position.x) * Mathf.Rad2Deg + 90f;
            rb.rotation = angle;
            //if (isEnemySeePlayer())
            //{
            if (distanceToPlayer < range && distanceToPlayer > shootRange) { followPlayer(); Debug.Log("takip ediyor"); }
            if (isEnemySeePlayer())
            {
                if (distanceToPlayer < shootRange && distanceToPlayer > runAndShootRange && nextShootTime < Time.time)
                {
                    rb.rotation = angle;
                    followAndFire();
                    Debug.Log("takip ederek sýkýyor");
                }
                if (distanceToPlayer < runAndShootRange && distanceToPlayer > stabRange && nextShootTime < Time.time) { runAndFire(); Debug.Log("ateþ ederek kaçýyor"); }
                if (distanceToPlayer < stabRange && distanceToPlayer >= 0) { followAndStab(); Debug.Log("býçaklýyor"); }
            }
            //}
        }
        if (distanceToPlayer > range) { outOfRange(); }

    }
    void followPlayer()
    {
        //follow yapýyor
        aipath.canMove = true;
        aipath.maxSpeed = 3f;
        aipath.maxAcceleration = 4f;
    }
    void followAndFire()
    {
        //ateþ ederek takip et
        Instantiate(arrowPrefab, arrowParent.transform.position, transform.rotation);
        aipath.canMove = true;
        aipath.maxSpeed = 2f;
        aipath.maxAcceleration = 3f;
        nextShootTime = Time.time + shootRate;
    }
    void runAndFire()
    {
        //ateþ ederek kaç
        Instantiate(arrowPrefab, arrowParent.transform.position, transform.rotation);

        aipath.canMove = true;
        aipath.maxSpeed = -3f;
        aipath.maxAcceleration = -5f;
        nextShootTime = Time.time + shootRate;
    }
    void followAndStab()
    {
        //stab here
        aipath.canMove = true;
        aipath.maxSpeed = 3f;
        aipath.maxAcceleration = 5f;
    }
    void outOfRange()
    {
        aipath.canMove = false;
    }
    bool isEnemySeePlayer()
    {
        bool value;
        //raycast sistemi
        RaycastHit2D hit = Physics2D.Linecast(new Vector2(raycastPoint.transform.position.x, raycastPoint.transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y));
        Debug.DrawLine(new Vector2(raycastPoint.transform.position.x, raycastPoint.transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y), Color.red);
        if (hit.collider != null)
        {

            if (hit.collider.gameObject.CompareTag("Player"))
            {
                value = true;
            }
            else
            {
                value = false;
            }
        }
        else
        {
            value = false;
        }
        return value;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ArrowPlayer"))
        {
            takeHit(1);

        }
    }
}
