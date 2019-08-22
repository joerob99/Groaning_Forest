using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Canvas controlScreen;
    [SerializeField] Canvas creditScreen;
    [SerializeField] Canvas mainMenu;

    void Start()
    {
        controlScreen.enabled = false;
        creditScreen.enabled = false;
    }

    public void ShowControls()
    {
        mainMenu.enabled = false;
        controlScreen.enabled = true;
    }

    public void ShowCredits()
    {
        mainMenu.enabled = false;
        creditScreen.enabled = true;
    }

    public void ShowMainMenu()
    {
        controlScreen.enabled = false;
        creditScreen.enabled = false;
        mainMenu.enabled = true;
    }
}
