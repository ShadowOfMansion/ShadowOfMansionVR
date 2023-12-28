using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchTrigger : MonoBehaviour
{
    public string sceneToLoad; // ��ȯ�� ���� �̸��� ���⿡ �Է��ϼ���.

    // �÷��̾ Ʈ���ſ� ������ �� ȣ��Ǵ� �Լ�
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ʈ����!");
        if (other.CompareTag("Player")) // �÷��̾� �±׸� ����ϰų� �ʿ信 ���� �ٸ� �±׸� ������ �� �ֽ��ϴ�.
        {
            Debug.Log("Player!");
            SwitchScene(); // �� ��ȯ �Լ� ȣ��
        }
    }

    // �� ��ȯ �Լ�
    private void SwitchScene()
    {
        SceneManager.LoadScene(sceneToLoad); // �Էµ� �̸��� ������ ��ȯ
    }
}
