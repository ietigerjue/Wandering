using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Principal;
using System.Xml.Schema;
using System.ComponentModel;
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    [SerializeField] UnityEngine.UI.Image transitionImage;
    [SerializeField] float fadeTime = 3.5f;
    UnityEngine.Color color;

    void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadLevel_1Scene()
    {
       StartCoroutine(LoadCoroutine("Level_1"));
    }
    public void MainMenuScene()
    {
       StartCoroutine(LoadCoroutine("MainMenu"));
    }
    

    IEnumerator LoadCoroutine(string sceneName)
    {
        var loadingOperation = SceneManager.LoadSceneAsync(sceneName);
        loadingOperation.allowSceneActivation = false;

        transitionImage.gameObject.SetActive(true);
        // 画面淡出
        while (color.a < 1f)
        {
            color.a = Mathf.Clamp01(color.a + Time.unscaledDeltaTime / fadeTime);
            transitionImage.color = color;

            yield return null;
        }
        loadingOperation.allowSceneActivation = true;
         while (color.a > 0f)
        {
            color.a = Mathf.Clamp01(color.a - Time.unscaledDeltaTime / fadeTime);
            transitionImage.color = color;

            yield return null;
        }
           
        transitionImage.gameObject.SetActive(false);
    }

}
