using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Tooltip("Handles showing/hiding the game over menu and any actions within it.")]
public class GameOverMenu : MonoBehaviour
{
    private GameObject gameOverCanvas;

    void Start()
    {
        gameOverCanvas = GameObject.FindGameObjectWithTag("GameOver");
        Hide();
    }

    public void Hide()
    {
        gameOverCanvas.SetActive(false);
    }

    public void PlayAgain()
    {
        Hide();
        GetComponent<SceneLoader>().ReloadGame();
    }

    public void Quit()
    {
        Hide();
        GetComponent<SceneLoader>().LoadMainMenu();
    }

    public void Show()
    {
        gameOverCanvas.SetActive(true);

        // TODO: add controller support so can select/press buttons with controller, not just mouse
    }
}
