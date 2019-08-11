using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] float zoomedInFOV = 55;
    [SerializeField] float zoomedOutFOV = 85;
    [SerializeField] float sensitivityNormal = 2;
    [SerializeField] float sensitivityZoomed = 1;

    bool isZoomed = false;

    private RigidbodyFirstPersonController FPSController;

    void Start()
    {
        FPSController = GetComponent<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!isZoomed)
            {
                isZoomed = true;
                mainCamera.fieldOfView = zoomedInFOV;
                FPSController.mouseLook.XSensitivity = sensitivityZoomed;
                FPSController.mouseLook.YSensitivity = sensitivityZoomed;
            }
            else
            {
                isZoomed = false;
                mainCamera.fieldOfView = zoomedOutFOV;
                FPSController.mouseLook.XSensitivity = sensitivityNormal;
                FPSController.mouseLook.YSensitivity = sensitivityNormal;
            }
        }
    }
}
