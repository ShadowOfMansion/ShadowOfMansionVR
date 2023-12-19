using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public string SceneToLoad;
    
    public void LoadGame()
    {
        // 비동기 씬을 코루틴 함수로 로드한다.
        StartCoroutine(AsyncNextScene(SceneToLoad));
    }

    // 목표: 다음 씬을 비동기 방식으로 로드하고 싶다.
    IEnumerator AsyncNextScene(string sceneName)
    {
        // 지정된 씬을 비동기 방식으로 만들고 싶다.
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOperation.isDone)
        {
            // 씬이 화면에 보이게 하고 싶다.
            asyncOperation.allowSceneActivation = true;

            yield return null;
        }
    }
}