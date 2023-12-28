using UnityEngine;
using TMPro;
using System.Collections;

public class TriggerTMPFade : MonoBehaviour
{
    public Collider[] triggers; // 여러 개의 트리거를 배열로 관리
    public TMP_Text[] textObjects; // 여러 개의 TMP_Text 오브젝트를 배열로 관리
    public float fadeDuration = 1.5f;
    public float displayDuration = 2.0f;

    private void Start()
    {
        // 모든 TMP_Text 오브젝트 비활성화
        foreach (TMP_Text textObject in textObjects)
        {
            textObject.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < triggers.Length; i++)
            {
                if (other == triggers[i]) // 플레이어가 특정 트리거에 닿았을 때
                {
                    StartCoroutine(FadeText(textObjects[i])); // 해당 인덱스의 텍스트에 대한 페이드 제어 시작
                }
            }
        }
    }

    private IEnumerator FadeText(TMP_Text textObject)
    {
        textObject.gameObject.SetActive(true); // 해당 TMP_Text 활성화
        Color originalColor = textObject.color;

        // 페이드인
        float timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            textObject.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        // 디스플레이 기간
        yield return new WaitForSeconds(displayDuration);

        // 페이드아웃
        timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            textObject.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        textObject.gameObject.SetActive(false); // 페이드아웃 후 텍스트 비활성화
    }
}
