using UnityEngine;
using TMPro;
using System.Collections;

public class TriggerTMPFade : MonoBehaviour
{
    public Collider[] triggers; // ���� ���� Ʈ���Ÿ� �迭�� ����
    public TMP_Text[] textObjects; // ���� ���� TMP_Text ������Ʈ�� �迭�� ����
    public float fadeDuration = 1.5f;
    public float displayDuration = 2.0f;

    private void Start()
    {
        // ��� TMP_Text ������Ʈ ��Ȱ��ȭ
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
                if (other == triggers[i]) // �÷��̾ Ư�� Ʈ���ſ� ����� ��
                {
                    StartCoroutine(FadeText(textObjects[i])); // �ش� �ε����� �ؽ�Ʈ�� ���� ���̵� ���� ����
                }
            }
        }
    }

    private IEnumerator FadeText(TMP_Text textObject)
    {
        textObject.gameObject.SetActive(true); // �ش� TMP_Text Ȱ��ȭ
        Color originalColor = textObject.color;

        // ���̵���
        float timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            textObject.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        // ���÷��� �Ⱓ
        yield return new WaitForSeconds(displayDuration);

        // ���̵�ƿ�
        timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            textObject.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        textObject.gameObject.SetActive(false); // ���̵�ƿ� �� �ؽ�Ʈ ��Ȱ��ȭ
    }
}
