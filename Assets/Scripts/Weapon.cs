using System.Collections;
using System.Collections.Generic;
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


    public float shotPower = 100f;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //GetComponent<Animator>().SetTrigger("Fire");
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);
        Debug.Log("I hit: " + hit.transform.name);

        //GameObject bullet;
        //bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        //bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

        //GameObject tempFlash;
        //tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

        //CasingRelease();
        //Destroy(tempFlash, 0.5f);
        //Destroy(bullet, 1f);

    }

    //void CasingRelease()
    //{
        //GameObject casing;
        //casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
        //Destroy(casing, 1f);
    //}


}
