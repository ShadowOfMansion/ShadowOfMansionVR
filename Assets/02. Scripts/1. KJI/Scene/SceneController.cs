using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public string sceneToLoad;
    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay(10f)); // 30초 후에 코루틴 실행
    }

    IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 일정 시간 대기

        SceneManager.LoadScene(sceneToLoad);
    }
}
