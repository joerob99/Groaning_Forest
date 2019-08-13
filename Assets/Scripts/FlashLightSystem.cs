using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.01f;
    [SerializeField] float angleDecay = 0.01f;
    [SerializeField] float minimumAngle = 70f;

    Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
    }
    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
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
