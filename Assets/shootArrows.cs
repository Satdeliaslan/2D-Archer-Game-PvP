using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootArrows : MonoBehaviour
{
    public GameObject ArrowPrefab;
    public Transform shootPoint;
    [SerializeField] float ArrowSpeedNormal;
    [SerializeField] float ArrowSpeedFast;
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }
    void shoot()
    {
        GameObject arrow = Instantiate(ArrowPrefab, shootPoint.position, shootPoint.rotation);//oku sahnede olu�turduk
        arrow.transform.parent = GameObject.Find("Arrows").transform;//yeni ok prefablar� hiyerar�ide arrows ogjesinin alt�nda olu�ssun
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>(); //rigidbody sinin alarak rahat �ekilde gid�ini ayarl�ycaz
        rb.AddForce(shootPoint.up * ArrowSpeedNormal, ForceMode2D.Impulse); //
    }
}
