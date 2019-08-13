using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 80f;
    [SerializeField] float intensityAmount = 7.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FlashLightSystem current = other.GetComponentInChildren<FlashLightSystem>();
            current.RestoreLightAngle(restoreAngle);
            current.RestoreLightIntensity(intensityAmount);
            Destroy(gameObject);
        }
    }
}
