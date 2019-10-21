using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{

    public void OnQuitButtonPressed()
    {
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
