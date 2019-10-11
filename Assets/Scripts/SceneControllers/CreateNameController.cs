using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreateNameController : MonoBehaviour
{
    public string playerName;

    public void Start()
    {
        playerName = GlobalOptions.playerName;
    }

    public void InputFieldChanged()
    {
        GlobalOptions.playerName = playerName;
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
