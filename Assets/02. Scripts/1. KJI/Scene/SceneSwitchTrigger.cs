using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchTrigger : MonoBehaviour
{
    public string sceneToLoad; // 전환할 씬의 이름을 여기에 입력하세요.

    // 플레이어가 트리거에 들어왔을 때 호출되는 함수
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어 태그를 사용하거나 필요에 따라 다른 태그를 지정할 수 있습니다.
        {
            SwitchScene(); // 씬 전환 함수 호출
        }
    }

    // 씬 전환 함수
    private void SwitchScene()
    {
        SceneManager.LoadScene(sceneToLoad); // 입력된 이름의 씬으로 전환
    }
}
