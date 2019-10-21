using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        // ****Need to change this to InGame Scene****
        SceneManager.LoadScene("CreateName");
    }

    public void OpenInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("QuitGame");
    }
}
