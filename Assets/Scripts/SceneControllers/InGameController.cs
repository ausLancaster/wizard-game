using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameController : MonoBehaviour
{

    public HealthManager healthManager;
    public PlayerController player;

    void Start()
    {

    }

    void Update()
    {

    }


    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }


}

