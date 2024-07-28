using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneSwitcher : MonoBehaviour
{

    [SerializeField] private Image fadeUpper;
    [SerializeField] private Image fadeLower;
    [SerializeField] private float fadeSpeed = 1.0f;
    public static SceneSwitcher Instance { get; private set; }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

        ChangeAlpha(0);
    }

    public void SwitchToNextScene()
    {
        StartCoroutine(SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings
            ? FadeToScene(SceneManager.GetActiveScene().buildIndex + 1)
            : FadeToScene(0));
    }

    public void SwitchToPreviousScene()
    {
        StartCoroutine(SceneManager.GetActiveScene().buildIndex - 1 >= 0
            ? FadeToScene(SceneManager.GetActiveScene().buildIndex - 1)
            : FadeToScene(SceneManager.sceneCountInBuildSettings - 1));
    }

    private IEnumerator FadeToScene(int sceneIndex)
    {
        Debug.Log("To scene: " + sceneIndex);
        yield return FadeOut();
        SceneManager.LoadScene(sceneIndex);
        yield return FadeIn();
    }

    private IEnumerator FadeOut()
    {
        float alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime * fadeSpeed;
            ChangeAlpha(alpha);
            yield return null;
        }
    }


    private IEnumerator FadeIn()
    {
        float alpha = 1;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            ChangeAlpha(alpha);
            yield return null;
        }
    }

    private void ChangeAlpha(float alpha)
    {
        fadeUpper.color = new Color(0, 0, 0, alpha);
        fadeLower.color = new Color(0, 0, 0, alpha);
    }


}
