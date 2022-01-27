using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingSreen;

    public void LoadLevel(string name)
    {
        StartCoroutine(LoadAsynchrounously(name));
    }

    IEnumerator LoadAsynchrounously (string name)
    {
        //Async -> loads async the scne so our scene is still doing it in background
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        //Current state of progress -> asyn in coroutine
        loadingSreen.SetActive(true);
        //Runs until its fully done
        while (!operation.isDone)
        {
            //Num between 0 and 1
            float progress = Mathf.Clamp01(operation.progress / .9f);
            yield return null;
        }
    }



}
