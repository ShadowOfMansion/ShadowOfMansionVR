using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public string sceneToLoad;
    void Start()
    {
        StartCoroutine(LoadSceneAfterDelay(10f)); // 30�� �Ŀ� �ڷ�ƾ ����
    }

    IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // ���� �ð� ���

        SceneManager.LoadScene(sceneToLoad);
    }
}
