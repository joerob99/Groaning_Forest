using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] PauseHandler pause;

    public void LoadGame()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { return; } // Fixes a bug with spacebar
        ReloadGame();
    }

    public void ReloadGame()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { return; } // Fixes a bug with spacebar
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void QuitToMainMenu()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { return; } // Fixes a bug with spacebar
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(0);
        Time.timeScale = 0;
    }

    public void TogglePauseOnAndOff() { if (Input.GetKeyDown(KeyCode.Space)) { return; } pause.TogglePause(); }

    public void QuitGame()
    {
        Application.Quit();
    }
}
