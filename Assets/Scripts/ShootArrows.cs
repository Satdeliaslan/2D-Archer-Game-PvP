using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shootArrows : MonoBehaviour
{
    //okumuzu olu�turup mouse do�rultusunda atal�m
    public GameObject ArrowPrefab;
    public Transform shootPoint;
    //ard arda atmay� engeleyelim
    bool isShooting;
    //Okun h�z� i�in slader haz�rlayal�m
    [SerializeField] Slider bowPowerSlider;
    [SerializeField] SpriteRenderer arrowGFX;
    [SerializeField] float bowPower;
    [SerializeField] float maxBowCharge;
    [SerializeField] float bowCharge;

    private void Start()
    {
        isShooting = false;
        bowPowerSlider.value = 0f;
        bowPowerSlider.value = maxBowCharge;
    }
    private void Update()
    {
        //if (Input.GetButtonDown("Fire1") && isShooting == false)
        if (Input.GetMouseButton(0) && isShooting == false)
        {
            chargeBow();
        }
        //else if(Input.GetButtonUp("Fire1") && isShooting == false)
        else if (Input.GetMouseButtonUp(0) && isShooting == false)
        {
            shoot();
            isShooting = true;
        }
        else
        {
            if(bowCharge > 0f)
            {
                bowCharge -= 1f * Time.deltaTime * 3;
            }
            else
            {
                bowCharge = 0f;
                isShooting = false;
            }
            bowPowerSlider.value = bowCharge;
        }
    }
    void chargeBow()
    {
        arrowGFX.enabled = true;
        bowCharge += Time.deltaTime*3;
        bowPowerSlider.value = bowCharge;
        if (bowCharge > maxBowCharge)
        {
            bowPowerSlider.value = maxBowCharge;
        }
    }
    void shoot()
    {
        if (bowCharge > maxBowCharge)
        {
            bowCharge = maxBowCharge;
        }
        float arrowSpeed = bowCharge + bowPower;
        GameObject arrow = Instantiate(ArrowPrefab, shootPoint.position, shootPoint.rotation);//oku sahnede olu�turduk
        arrow.transform.parent = GameObject.Find("Arrows").transform;//yeni ok prefablar� hiyerar�ide arrows ogjesinin alt�nda olu�ssun
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>(); //rigidbody sinin alarak rahat �ekilde gid�ini ayarl�ycaz
        rb.AddForce(shootPoint.up * arrowSpeed, ForceMode2D.Impulse); //
        isShooting = false;
        arrowGFX.enabled = false;
    }
}
