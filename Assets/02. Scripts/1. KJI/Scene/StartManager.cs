using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public string SceneToLoad;
    
    public void LoadGame()
    {
        // �񵿱� ���� �ڷ�ƾ �Լ��� �ε��Ѵ�.
        StartCoroutine(AsyncNextScene(SceneToLoad));
    }

    // ��ǥ: ���� ���� �񵿱� ������� �ε��ϰ� �ʹ�.
    IEnumerator AsyncNextScene(string sceneName)
    {
        // ������ ���� �񵿱� ������� ����� �ʹ�.
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOperation.isDone)
        {
            // ���� ȭ�鿡 ���̰� �ϰ� �ʹ�.
            asyncOperation.allowSceneActivation = true;

            yield return null;
        }
    }
}