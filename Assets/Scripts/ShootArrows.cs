using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shootArrows : MonoBehaviour
{
    //okumuzu oluþturup mouse doðrultusunda atalým
    public GameObject ArrowPrefab;
    public Transform shootPoint;
    //ard arda atmayý engeleyelim
    bool isShooting;
    //Okun hýzý için slader hazýrlayalým
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
        GameObject arrow = Instantiate(ArrowPrefab, shootPoint.position, shootPoint.rotation);//oku sahnede oluþturduk
        arrow.transform.parent = GameObject.Find("Arrows").transform;//yeni ok prefablarý hiyerarþide arrows ogjesinin altýnda oluþssun
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>(); //rigidbody sinin alarak rahat þekilde gidþini ayarlýycaz
        rb.AddForce(shootPoint.up * arrowSpeed, ForceMode2D.Impulse); //
        isShooting = false;
        arrowGFX.enabled = false;
    }
}
