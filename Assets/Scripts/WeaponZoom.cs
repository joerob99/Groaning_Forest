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

    [SerializeField] RigidbodyFirstPersonController FPSController;

    //private void Start()
    //{
    //    ZoomOut(); // Each gun starts zoomed out
    //}

    void OnDisable()
    {
        ZoomOut();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!isZoomed) { ZoomIn(); }
            else { ZoomOut(); }
        }
    }

    private void ZoomOut()
    {
        isZoomed = false;
        mainCamera.fieldOfView = zoomedOutFOV;
        FPSController.mouseLook.XSensitivity = sensitivityNormal;
        FPSController.mouseLook.YSensitivity = sensitivityNormal;
    }

    private void ZoomIn()
    {
        isZoomed = true;
        mainCamera.fieldOfView = zoomedInFOV;
        FPSController.mouseLook.XSensitivity = sensitivityZoomed;
        FPSController.mouseLook.YSensitivity = sensitivityZoomed;
    }
}
