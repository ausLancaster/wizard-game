using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public HealthManager healthManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthManager.GetHealth() <= 0)
        {
            SceneManager.LoadScene("CreateName");
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
