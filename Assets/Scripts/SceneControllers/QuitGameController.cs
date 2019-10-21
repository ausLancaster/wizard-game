using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class QuitGameController : MonoBehaviour
{

    public void OnYesButtonPressed()
    {
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void OnNoButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
