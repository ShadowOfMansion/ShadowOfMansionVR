using UnityEngine;
using UnityEngine.UI;

public class ImageToggle : MonoBehaviour
{
    public Image[] imagesToShow; // 나타낼 이미지 배열

    private bool[] imageActive; // 각 이미지의 활성화 여부를 저장하는 배열

    void Start()
    {
        // 이미지 활성화 여부를 저장하는 배열 초기화
        imageActive = new bool[imagesToShow.Length];
        for (int i = 0; i < imagesToShow.Length; i++)
        {
            imagesToShow[i].gameObject.SetActive(false); // 시작 시 모든 이미지를 비활성화합니다.
            imageActive[i] = false;
        }
    }

    public void ToggleImage(int index)
    {
        if (index >= 0 && index < imagesToShow.Length)
        {
            if (!imageActive[index])
            {
                imagesToShow[index].gameObject.SetActive(true); // 이미지를 활성화하여 보여줍니다.
                imageActive[index] = true;
            }
            else
            {
                imagesToShow[index].gameObject.SetActive(false); // 이미지를 비활성화하여 가리웁니다.
                imageActive[index] = false;
            }
        }
        else
        {
            Debug.LogError("Index out of range!"); // 인덱스가 범위를 벗어난 경우 에러 메시지 출력
        }
    }
}
