using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 80f;
    [SerializeField] float intensityAmount = 3f;
    [SerializeField] float rotationSpeed = 200f;
    [SerializeField] AudioClip refill;

    private AudioSource source;

    private void Start() { source = GetComponentInParent<AudioSource>(); }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            source.PlayOneShot(refill);
            FlashLightSystem current = other.GetComponentInChildren<FlashLightSystem>();
            current.RestoreLightAngle(restoreAngle);
            current.RestoreLightIntensity(intensityAmount);
            Destroy(gameObject);
        }
    }

    private void Update() // Used primarily to rotate the battery object
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
