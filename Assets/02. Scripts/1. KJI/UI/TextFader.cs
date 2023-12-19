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
        // 텍스트를 완전히 불투명하게 설정합니다.
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);

        // 페이드인
        while (textMesh.color.a < 1.0f)
        {
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, textMesh.color.a + Time.deltaTime / fadeDuration);
            yield return null;
        }

        yield return new WaitForSeconds(2.0f); // 여기서 2초 대기 후 페이드아웃 시작

        // 페이드아웃
        while (textMesh.color.a > 0.0f)
        {
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, textMesh.color.a - Time.deltaTime / fadeDuration);
            yield return null;
        }

        // 페이드아웃 후 텍스트를 비활성화합니다.
        textMesh.gameObject.SetActive(false);
    }
}
