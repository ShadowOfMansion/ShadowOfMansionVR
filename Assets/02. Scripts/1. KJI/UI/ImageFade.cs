using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFade : MonoBehaviour
{
    public Image image; // UI �̹���
    public float fadeDuration = 3.0f; // ���̵� �ð�

    void Start()
    {
        // ���� �� ������ 0���� �����Ͽ� ���̵��� ȿ�� �غ�
        Color tempColor = image.color;
        tempColor.a = 0f;
        image.color = tempColor;

        // ���̵��� ����
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        image.CrossFadeAlpha(1f, fadeDuration, false); // �̹����� ������ ���̵��� ���̵���
        yield return new WaitForSeconds(fadeDuration);

        // ���⼭ �ٸ� ���� ���� ����
        // ���� ���, ���� �ð��� ������ ���̵�ƿ��ǵ��� ó���� �� �ֽ��ϴ�.
        yield return new WaitForSeconds(3f);

        // ���̵�ƿ� ����
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        image.CrossFadeAlpha(0f, fadeDuration, false); // �̹����� ������ �����ϰ� �Ͽ� ���̵�ƿ�
        yield return new WaitForSeconds(fadeDuration);

        // ���̵�ƿ� ���� �ٸ� ���� ���� ����
    }
}
