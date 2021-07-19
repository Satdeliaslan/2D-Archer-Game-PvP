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
    Rigidbody2D rb;

    AIPath aipath;

    public GameObject arrowPrefab;
    public GameObject arrowParent;

    public float shootRate = 1f;
    private float nextShootTime;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aipath = GetComponent<AIPath>();
    }
    private void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= range && distanceToPlayer > shootRange)
        {
            //follow yapýyor
            aipath.canMove = true;
            aipath.maxSpeed = 5f;
        }
        else if (distanceToPlayer < shootRange && distanceToPlayer > aipath.endReachedDistance && nextShootTime < Time.time)
        {
            //ateþ ederek takip et
            Instantiate(arrowPrefab,arrowParent.transform.position, transform.rotation);
            aipath.canMove = true;
            aipath.maxSpeed = 4f;
            nextShootTime = Time.time + shootRate;
        }
        else if (distanceToPlayer >= aipath.endReachedDistance && distanceToPlayer<runAndShootRange && nextShootTime < Time.time)
        {
            //ateþ ederek kaç
            Instantiate(arrowPrefab, arrowParent.transform.position, transform.rotation);
            aipath.canMove = true;
            aipath.maxSpeed = -4f;
            nextShootTime = Time.time + shootRate;
        }
        else
        {
            aipath.canMove = false;
        }
    }
   

}
