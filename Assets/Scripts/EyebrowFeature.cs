using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyebrowFeature : MonoBehaviour
{

    [SerializeField]
    Transform eyebrows;
    [SerializeField]
    Transform shaver;
    [SerializeField]
    int lifespan = 5;
    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    Camera eyebrowCamera;
    [SerializeField]
    GameObject collectedText;
    [SerializeField]
    float shaveDuration = 0.5f;
    [SerializeField]
    float waitDuration = 0.1f;
    [SerializeField]
    float finishDuration = 0.75f;
    [SerializeField]
    float shaveRadius = 0.0005f;
    [SerializeField]
    GameObject eyebrowItem;
    [SerializeField]
    GameObject eyebrowReadyUI;

    Vector3 eyebrowsCentre = new Vector3(0, 2.3f, 0);
    float timePassed;
    bool eyebrowsReady;
    bool shaving;
    Vector3 originalScale;
    Vector3 shaverLeftPosition = new Vector3(0.00155f, 0, 0.022f);
    Vector3 shaverRightPosition = new Vector3(-0.00155f, 0, 0.022f);

    void Start()
    {
        eyebrowsReady = true;
        timePassed = lifespan;
        originalScale = eyebrows.localScale;
        mainCamera.enabled = true;
        eyebrowCamera.enabled = false;
         shaver.gameObject.SetActive(false);
        collectedText.SetActive(false);
        eyebrowReadyUI.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y) && eyebrowsReady)
        {
            StartCoroutine(Shave());
            shaving = true;
            eyebrowsReady = false;
            eyebrowReadyUI.SetActive(false);
        }

        if (!eyebrowsReady && !shaving)
        {
            timePassed += Time.deltaTime;
            if (timePassed > lifespan)
            {
                eyebrowsReady = true;
                eyebrowReadyUI.SetActive(true);
            }
            var lerp = Mathf.Lerp(0, 1, timePassed / lifespan);
            eyebrows.localScale = lerp * originalScale;
            eyebrows.localPosition = (1f - lerp) * eyebrowsCentre;
        }
    }

    IEnumerator Shave()
    {
        mainCamera.enabled = false;
        eyebrowCamera.enabled = true;

        shaver.gameObject.SetActive(true);

        for (float t = 0; t < shaveDuration; t += Time.unscaledDeltaTime)
        {
            float angle = (t / shaveDuration) * 2 * Mathf.PI;
            shaver.localPosition = shaverLeftPosition + shaveRadius * new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));

            yield return null;
        }

        shaver.gameObject.SetActive(false);

        for (float t = 0; t < waitDuration; t += Time.unscaledDeltaTime)
        {
            yield return null;
        }

        shaver.gameObject.SetActive(true);


        for (float t = 0; t < shaveDuration; t += Time.unscaledDeltaTime)
        {
            float angle = - (t / shaveDuration) * 2 * Mathf.PI;
            shaver.localPosition = shaverRightPosition + shaveRadius * new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));

            yield return null;
        }

        collectedText.SetActive(true);
        timePassed = 0;
        shaver.gameObject.SetActive(false);
        shaving = false;

        for (float t = 0; t < finishDuration; t += Time.unscaledDeltaTime)
        {
            timePassed = 0;
            yield return null;
        }
        mainCamera.enabled = true;
        eyebrowCamera.enabled = false;
        collectedText.SetActive(false);
        var obj = Instantiate(eyebrowItem);
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
    }
}
