using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public Transform casingExitLocation;

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 31f;
    [SerializeField] float waitBetweenShots = 1f;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;

    [SerializeField] AudioClip shotFired;

    public float shotPower = 100f;

    private AudioSource source;
    private bool hasShot = false;
    private float waitLeft;

    void Start()
    {
        waitLeft = waitBetweenShots;
        source = GetComponentInParent<AudioSource>();
        if (barrelLocation == null)
            barrelLocation = transform;
    }

    void Update()
    {
        if (hasShot && waitLeft > 0f) { waitLeft -= Time.deltaTime; } // This code is used to wait for a period of time between shots fired
        else { hasShot = false; }
        DisplayAmmo();

        if (Input.GetMouseButtonDown(0) && ammoSlot.GetCurrentAmmo(ammoType) > 0) // If left clicked and ammo > 0, shoot
        {
            if (!hasShot) // If the player has already waited the specified time or has not yet shot
            {
                SetTriggerFire(); // Calls shoot by tellng animation to trigger, which causes the shoot event
                waitLeft = waitBetweenShots;
            }
        }
    }

    private void SetTriggerFire() { GetComponent<Animator>().SetTrigger("Fire"); } // String referenced

    private void DisplayAmmo()
    {
        ammoText.text = (ammoSlot.GetCurrentAmmo(ammoType)).ToString();
    }

    void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0) {
            hasShot = true;
            PlayMuzzleFlash();
            ProcessRaycast();
            ShowBullet();
            ammoSlot.ReduceCurrentAmmo(ammoType);
            PlayShootSound();
        }
    }

    private void PlayShootSound() { source.PlayOneShot(shotFired); }

    private void ShowBullet()
    {
        GameObject bullet;
        bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        Destroy(bullet, 1f);
    }

    private void PlayMuzzleFlash()
    {
        GameObject flash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
        Destroy(flash, 0.2f);
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            // call a method on enemyhealth that decreases enemy health
            target.TakeDamage(damage);
        }
        else { return; }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }

    void CasingRelease()
    {
        GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, UnityEngine.Random.Range(100f, 500f), UnityEngine.Random.Range(10f, 1000f)), ForceMode.Impulse);
        Destroy(casing, 0.75f);
    }


}
