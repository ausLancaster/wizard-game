using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreateNameController : MonoBehaviour
{

    public void Start()
    {
        
    }


    public void OnStartGameButtonPressed()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnCancelButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
