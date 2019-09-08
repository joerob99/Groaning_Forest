using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 1f;
    [SerializeField] float angleDecay = 0.01f;
    [SerializeField] float minimumAngle = 70f;
    [SerializeField] TextMeshProUGUI batteryText;
    [SerializeField] AudioClip clickSound;
    private bool isOn;
    private AudioSource click;

    Light myLight;

    void Start()
    {
        isOn = true;
        click = GetComponent<AudioSource>();
        myLight = GetComponent<Light>();
    }
    void Update()
    {
        DisplayBattery();
        if (Input.GetKeyDown(KeyCode.F)) { ToggleFlashlight(); } // Toggle flashlight if F key is pressed
        if (isOn) { DecreaseLightAngle(); DecreaseLightIntensity(); } // Decrease light and battery if flashlight is on
    }

    private void ToggleFlashlight()
    {
        isOn = !isOn;
        click.PlayOneShot(clickSound);
        if (!isOn) { myLight.enabled = false; }
        else { myLight.enabled = true; }
    }

    private void DisplayBattery()
    {
        batteryText.text = ((int)((myLight.intensity / 3f) * 100)).ToString(); // Finds the battery % using a conversion formula and then converts to int
    }

    public void RestoreLightAngle(float restoreAngle) { myLight.spotAngle = restoreAngle; }
    public void RestoreLightIntensity(float intensityAmount) { myLight.intensity = intensityAmount; }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= minimumAngle) return;
        myLight.spotAngle -= angleDecay * Time.deltaTime;
    }

    private void DecreaseLightIntensity()
    {
        if (myLight.intensity <= 0) return;
        myLight.intensity -= lightDecay * Time.deltaTime;
    }
}
