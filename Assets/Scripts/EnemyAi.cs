using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject castPoint;
    [SerializeField] float range;
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    float angle;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if(distanceToPlayer <= range)
        {
            if (isEnemySeePlayer(distanceToPlayer))
            {
                chasePlayer();
            }
            else
            {
                stopChasingPlayer();
            }
        }
        else
        {
            stopChasingPlayer();
        }
    }
    void chasePlayer()
    {
        Debug.Log("chase player çalýþýyor");
        float vecX = (player.transform.position.x - transform.position.x) * Time.deltaTime * moveSpeed;
        float vecY = (player.transform.position.y - transform.position.y) * Time.deltaTime * moveSpeed;
        rb.velocity = new Vector2(vecX,vecY);
        angle =Mathf.Atan2(transform.position.y - player.transform.position.y, transform.position.x - player.transform.position.x) * Mathf.Rad2Deg -90f;
        rb.rotation = angle;
    }
    void stopChasingPlayer()
    {
        rb.velocity = Vector2.zero;
    }
    bool isEnemySeePlayer(float distance)
    {
        bool val = false;
        float castDist = distance;
        Vector2 endPos = castPoint.transform.position + Vector3.right * distance;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.transform.position, endPos, 1 << LayerMask.NameToLayer("Action"));
        //RaycastHit2D hit = Physics2D.Raycast(castPoint.transform.position,rb.transform.rotation,castDist, 1 << LayerMask.NameToLayer("Action"));
        /*
         RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance = Mathf.Infinity, 
                int layerMask = DefaultRaycastLayers, float minDepth = -Mathf.Infinity, float maxDepth = Mathf.Infinity);
         */
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                val = true;
            }
            else
            {
                val = false;
            }
            Debug.DrawLine(castPoint.transform.position, endPos, Color.red);
            Debug.Log("Target name: " + hit.collider.name);
        }
        else
        {
            Debug.Log("Target name: " + hit.collider.name);
            Debug.DrawLine(castPoint.transform.position, endPos, Color.blue);
        }
        return val;
    }
}
