using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 에디터 모드에서는 플레이 모드를 종료합니다.
#else
            Application.Quit(); // 빌드된 애플리케이션에서는 애플리케이션을 종료합니다.
#endif
    }
}
