using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void Start()
    {
        GameObject.Find("Intro_Music_Manager").GetComponent<AudioSource>().enabled = true;
        GameObject.Find("HideCursor").GetComponent<HideCursor>().CursorOn();

    }
    public void StartGame()
    {
        // ****Need to change this to InGame Scene****
        SceneManager.LoadScene("CreateName");
    }

    public void ToggleControls()
    {
        Canvas controlsCanvas = GameObject.Find("ControlsCanvas").GetComponent<Canvas>();
        if (controlsCanvas.enabled)
        {
            controlsCanvas.enabled = false;
        }
        else
        {
            controlsCanvas.enabled = true;
        }
    }

    public void ToggleSpellbook()
    {
        Canvas spellbookCanvas = GameObject.Find("SpellbookCanvas").GetComponent<Canvas>();
        if (spellbookCanvas.enabled)
        {
            spellbookCanvas.enabled = false;
        }
        else
        {
            spellbookCanvas.enabled = true;
        }
    }

    public void OpenStory()
    {
        SceneManager.LoadScene("Story");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("QuitGame");
    }
}
