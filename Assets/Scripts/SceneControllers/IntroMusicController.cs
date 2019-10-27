using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroMusicController : MonoBehaviour
{
    public static IntroMusicController introMusicControl;
    public AudioSource introScenes;
    public AudioClip introMusic;

    private void Awake()
    {

        if (introMusicControl == null)
        {
            introMusicControl = this;
            introMusic = introScenes.clip;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Update()
    {

    }
}
