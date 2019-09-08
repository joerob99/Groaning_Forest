using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] PauseHandler pause;

    public void LoadGame()
    {
        ReloadGame();
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void QuitToMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(0);
        Time.timeScale = 0;
    }

    public void TogglePauseOnAndOff() { pause.TogglePause(); }

    public void QuitGame()
    {
        Application.Quit();
    }
}
