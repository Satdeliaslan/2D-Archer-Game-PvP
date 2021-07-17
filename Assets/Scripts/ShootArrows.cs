using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrows : MonoBehaviour
{
    public GameObject ArrowPrefab;
    public Transform shootPoint;
    [SerializeField] float ArrowSpeedNormal;
    [SerializeField] float ArrowSpeedFast;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }
    void shoot()
    {
       GameObject arrow = Instantiate(ArrowPrefab, shootPoint.position, shootPoint.rotation);//oku sahnede olu�turduk
       Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>(); //rigidbody sinin alarak rahat �ekilde gid�ini ayarl�ycaz
        rb.AddForce(shootPoint.up * ArrowSpeedNormal, ForceMode2D.Impulse); //
    }
}
