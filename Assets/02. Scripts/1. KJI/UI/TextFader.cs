using System.Collections;
using TMPro;
using UnityEngine;

public class TextFader : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float fadeDuration = 1.5f;

    void Start()
    {
        StartCoroutine(FadeText());
    }

    IEnumerator FadeText()
    {
        // �ؽ�Ʈ�� ������ �������ϰ� �����մϴ�.
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);

        // ���̵���
        while (textMesh.color.a < 1.0f)
        {
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, textMesh.color.a + Time.deltaTime / fadeDuration);
            yield return null;
        }

        yield return new WaitForSeconds(2.0f); // ���⼭ 2�� ��� �� ���̵�ƿ� ����

        // ���̵�ƿ�
        while (textMesh.color.a > 0.0f)
        {
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, textMesh.color.a - Time.deltaTime / fadeDuration);
            yield return null;
        }

        // ���̵�ƿ� �� �ؽ�Ʈ�� ��Ȱ��ȭ�մϴ�.
        textMesh.gameObject.SetActive(false);
    }
}
