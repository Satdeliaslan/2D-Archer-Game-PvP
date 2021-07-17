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
        GameObject arrow = Instantiate(ArrowPrefab, shootPoint.position, shootPoint.rotation);//oku sahnede oluþturduk
        arrow.transform.parent = GameObject.Find("Arrows").transform;//yeni ok prefablarý hiyerarþide arrows ogjesinin altýnda oluþssun
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>(); //rigidbody sinin alarak rahat þekilde gidþini ayarlýycaz
        rb.AddForce(shootPoint.up * ArrowSpeedNormal, ForceMode2D.Impulse); //
    }
}
