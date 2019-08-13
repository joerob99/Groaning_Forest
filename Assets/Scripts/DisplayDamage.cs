using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas slashCanvas;
    [SerializeField] float slashTime = 0.2f;

    void Start()
    {
        slashCanvas.enabled = false;
    }

    public void ShowDamageSlash()
    {
        StartCoroutine(ShowSplatter());
    }

    private IEnumerator ShowSplatter()
    {
        slashCanvas.enabled = true;
        yield return new WaitForSeconds(slashTime);
        slashCanvas.enabled = false;
    }
}
