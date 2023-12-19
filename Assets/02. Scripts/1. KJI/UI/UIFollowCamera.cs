using UnityEngine;

public class UIFollowCamera : MonoBehaviour
{
    public Camera playerCamera; // 플레이어 카메라를 여기에 할당하세요.

    void FixedUpdate()
    {
        if (playerCamera != null)
        {
            // UI 요소를 카메라의 위치에 따라 이동시키되, 회전하지 않도록 설정합니다.
            transform.position = playerCamera.transform.position;

            // UI 요소가 항상 카메라를 바라보도록 설정 (정면 유지)
            Vector3 lookPos = transform.position - playerCamera.transform.position;
            lookPos.y = 0; // 위아래 방향 회전 방지
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = rotation;

            // UI 요소를 화면 정중앙으로 위치시킵니다.
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.position = playerCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, playerCamera.nearClipPlane));
        }
    }
}
