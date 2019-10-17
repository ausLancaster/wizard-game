using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameController : MonoBehaviour
{
    public HealthManager healthManager;
    public PlayerController player;
    public UI_Manager UI;
    public Canvas pausedCanvas;

    void Start()
    {
        GameObject pausedMenu = GameObject.Find("PausedCanvas");
        pausedCanvas = pausedMenu.GetComponent<Canvas>();
        pausedCanvas.enabled = false;
    }

    void Update()
    {
        
    }

    public void TogglePauseMenu()
    {
        // not the optimal way but for the sake of readability
        if (pausedCanvas.enabled)
        {
            pausedCanvas.enabled = false;
            UI.controlsCanvas.enabled = false;
            UI.exitCanvas.enabled = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            pausedCanvas.enabled = true;
            Time.timeScale = 0f;
        }
    }

    public void GameOver()
    {

    }


    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

}

