using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameController : MonoBehaviour
{
    public HealthManager healthManager;
    public PlayerController player;
    public UI_Manager UI;

    void Start()
    {
        UI.GetComponentInChildren<Canvas>().enabled = false;
    }

    void Update()
    {

    }

    public void TogglePauseMenu()
    {
        // not the optimal way but for the sake of readability
        if (UI.GetComponentInChildren<Canvas>().enabled)
        {
            UI.GetComponentInChildren<Canvas>().enabled = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            UI.GetComponentInChildren<Canvas>().enabled = true;
            Time.timeScale = 0f;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    // To be completed
    public void OpenControls()
    {
        
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("QuitGame");
    }

}

