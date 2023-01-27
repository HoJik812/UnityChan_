using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public Slider slider;
    public string SceneName;
    public float time;

    private void Start()
    {
        StartCoroutine(LoadAsynSceneCoroutine());
    }

    IEnumerator LoadAsynSceneCoroutine()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);

        operation.allowSceneActivation = false;

        while(!operation.isDone)
        {
            time = +Time.time;
            slider.value = time / 7f;

            if(time > 7)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
