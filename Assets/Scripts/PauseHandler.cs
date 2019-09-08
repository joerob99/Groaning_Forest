using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] Canvas pauseScreen;
    private WeaponSwitcher weaponSwitcher;
    private bool isPaused;

    void Start()
    {
        weaponSwitcher = FindObjectOfType<WeaponSwitcher>();
        pauseScreen.enabled = false;
        isPaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (!isPaused) { HandlePause(); }
        else { Unpause(); }
    }

    private void HandlePause()
    {
        isPaused = true;
        pauseScreen.enabled = true;
        Time.timeScale = 0;
        weaponSwitcher.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Unpause()
    {
        isPaused = false;
        pauseScreen.enabled = false;
        Time.timeScale = 1;
        weaponSwitcher.enabled = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
}
