using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    static string loadSceneName;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingSceneProcess());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void LoadScene(string SceneName)
    {
        loadSceneName = SceneName;
        SceneManager.LoadScene("LoadingScene");
    }
    IEnumerator LoadingSceneProcess()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(loadSceneName);

        float time = 0f;
        async.allowSceneActivation = false;
		while (!async.isDone)
		{
            yield return null;
            time += Time.deltaTime;
            if (async.progress >= 0.9f && time >= 1)
            {
                async.allowSceneActivation = true;
                yield break;
            }
		}
    }
}
