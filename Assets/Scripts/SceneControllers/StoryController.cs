using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
