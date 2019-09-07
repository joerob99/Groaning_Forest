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
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;

    [SerializeField] AudioClip shotFired;

    public float shotPower = 100f;

    private AudioSource source;

    void Start()
    {
        source = GetComponentInParent<AudioSource>();
        if (barrelLocation == null)
            barrelLocation = transform;
    }

    void Update()
    {
        DisplayAmmo();
        if (Input.GetMouseButtonDown(0) && ammoSlot.GetCurrentAmmo(ammoType) > 0) // If left clicked and ammo > 0, shoot
        {
            GetComponent<Animator>().SetTrigger("Fire");
            //Shoot();
        }
    }

    private void DisplayAmmo()
    {
        ammoText.text = (ammoSlot.GetCurrentAmmo(ammoType)).ToString();
    }

    void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0) {
            PlayMuzzleFlash();
            ProcessRaycast();
            ShowBullet();
            ammoSlot.ReduceCurrentAmmo(ammoType);
            PlayShootSound();
        }
    }

    private void PlayShootSound()
    {
        source.PlayOneShot(shotFired);
        //switch (ammoType)
        //{
            //case AmmoType.PistolBullets:
                //source.PlayOneShot(pistolShot);
                //break;
            //case AmmoType.RifleBullets:
                //source.PlayOneShot(rifleShot);
                //break;
            //case AmmoType.ShotgunShells:
                //source.PlayOneShot(shotgunShot);
                //break;
        //}
    }

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
