using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class VictoryController : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("Intro_Music_Manager").GetComponent<AudioSource>().enabled = true;
    }
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
