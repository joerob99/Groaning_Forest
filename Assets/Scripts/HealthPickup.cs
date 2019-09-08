using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] float healthHealed = 60f;
    [SerializeField] float rotationSpeed = 200f;
    [SerializeField] AudioClip heal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponentInParent<AudioSource>().PlayOneShot(heal);
            FindObjectOfType<PlayerHealth>().HealHealth(healthHealed);
            Destroy(gameObject);
        }
    }

    private void Update() // Used primarily to rotate the healthkit object
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
