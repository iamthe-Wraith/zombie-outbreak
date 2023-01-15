using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

[Tooltip("Manages game scenes only.")]
public class SceneLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        Debug.Log("loading main menu...");
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("quitting game...");
        Application.Quit();
    }
}
