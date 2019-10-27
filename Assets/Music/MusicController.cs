using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public InGameController GC;

    public AudioSource chicken;
    public AudioClip chickenSounds;
    public float chickenSoundDelay;
    public bool chickenSoundPlaying = true;

    public AudioSource wind;
    public AudioClip windSounds;
    public float windSoundDelay;
    public bool windSoundPlaying = true;

    public AudioSource throwAction;
    public AudioClip throwSound;
    public AudioSource explosion;
    public AudioClip explodeSound;

    public AudioSource pickUp;
    public AudioClip pickUpSound;

    // Start is called before the first frame update
    void Start()
    {
        GC = GameObject.Find("InGameController").GetComponent<InGameController>();
        chickenSounds = chicken.clip;
        windSounds = wind.clip;
        throwSound = throwAction.clip;
        explodeSound = explosion.clip;
        pickUpSound = pickUp.clip;

        windSoundDelay = 10.0f;
        chickenSoundDelay = 15.0f;
        StartCoroutine(PlayWind());
        StartCoroutine(PlayChicken());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && GC.potionQueue.Count>0)
        {
            throwAction.PlayOneShot(throwSound);
            explosion.PlayOneShot(explodeSound);
        }
    }

    IEnumerator PlayWind()
    {
        while (windSoundPlaying)
        {   
            wind.PlayOneShot(windSounds);
            yield return new WaitForSeconds(windSoundDelay);
        }
    }
    IEnumerator PlayChicken()
    {
        while (chickenSoundPlaying)
        {
            chicken.PlayOneShot(chickenSounds);
            yield return new WaitForSeconds(chickenSoundDelay);
        }
    }

    public void PlayItemPickUp()
    {
        pickUp.PlayOneShot(pickUpSound);
    }
}
