using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public TextMeshProUGUI[] textToFade; // TMP 텍스트 배열
    public Button[] buttonsToFade; // 버튼 배열
    public Image[] imagesToFade; // 이미지 배열
    public float delayDuration = 3.0f; // 페이드인까지의 딜레이 시간
    public float fadeInDuration = 2.0f; // 페이드인 지속 시간

    private float currentAlpha = 0.0f;
    private float timer = 0.0f;
    private bool delayComplete = false;
    private bool fading = false;

    void Start()
    {
        foreach (TextMeshProUGUI text in textToFade)
        {
            text.alpha = 0.0f; // 시작 시 TMP 텍스트의 알파값을 0으로 설정하여 투명하게 시작합니다.
        }

        foreach (Button button in buttonsToFade)
        {
            Color buttonColor = button.image.color;
            button.image.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, 0.0f); // 시작 시 버튼의 알파값을 0으로 설정하여 투명하게 시작합니다.
        }

        foreach (Image image in imagesToFade)
        {
            Color imageColor = image.color;
            image.color = new Color(imageColor.r, imageColor.g, imageColor.b, 0.0f); // 시작 시 이미지의 알파값을 0으로 설정하여 투명하게 시작합니다.
        }
    }

    void Update()
    {
        if (!delayComplete)
        {
            timer += Time.deltaTime;

            if (timer >= delayDuration)
            {
                delayComplete = true;
                timer = 0.0f;
            }
        }
        else if (!fading)
        {
            timer += Time.deltaTime;

            if (timer >= fadeInDuration)
            {
                fading = true;
                timer = fadeInDuration;
            }

            currentAlpha = timer / fadeInDuration;

            foreach (TextMeshProUGUI text in textToFade)
            {
                text.alpha = currentAlpha; // TMP 텍스트의 페이드인을 구현합니다.
            }

            foreach (Button button in buttonsToFade)
            {
                Color buttonColor = button.image.color;
                button.image.color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, currentAlpha); // 버튼의 페이드인을 구현합니다.
            }

            foreach (Image image in imagesToFade)
            {
                Color imageColor = image.color;
                image.color = new Color(imageColor.r, imageColor.g, imageColor.b, currentAlpha); // 이미지의 페이드인을 구현합니다.
            }
        }
    }
}
