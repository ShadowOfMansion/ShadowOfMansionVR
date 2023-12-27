using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFade : MonoBehaviour
{
    public Image image; // UI 이미지
    public float fadeDuration = 3.0f; // 페이드 시간

    void Start()
    {
        // 시작 시 투명도를 0으로 설정하여 페이드인 효과 준비
        Color tempColor = image.color;
        tempColor.a = 0f;
        image.color = tempColor;

        // 페이드인 시작
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        image.CrossFadeAlpha(1f, fadeDuration, false); // 이미지를 서서히 보이도록 페이드인
        yield return new WaitForSeconds(fadeDuration);

        // 여기서 다른 동작 수행 가능
        // 예를 들어, 일정 시간이 지나면 페이드아웃되도록 처리할 수 있습니다.
        yield return new WaitForSeconds(3f);

        // 페이드아웃 시작
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        image.CrossFadeAlpha(0f, fadeDuration, false); // 이미지를 서서히 투명하게 하여 페이드아웃
        yield return new WaitForSeconds(fadeDuration);

        // 페이드아웃 후의 다른 동작 수행 가능
    }
}
