using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform PlayerLocation;
    float maxCamPosX = 24.5f;
    float minCamPosX = -24.5f;
    float maxCamPosY = 16.4f;
    float minCamPosY = -16.4f;
    private void Start()
    {
        //PlayerLocation = GetComponent<PlayerController>().transform;
        PlayerLocation = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        float positionX = Mathf.Clamp(PlayerLocation.position.x, minCamPosX, maxCamPosX);
        float positionY = Mathf.Clamp(PlayerLocation.position.y, minCamPosY, maxCamPosY);
        float positionZ = -10f;
        transform.position = new Vector3(positionX,positionY,positionZ); 
    }
}
