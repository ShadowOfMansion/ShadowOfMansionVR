using UnityEngine;

public class UIFollowCamera : MonoBehaviour
{
    public Camera playerCamera; // �÷��̾� ī�޶� ���⿡ �Ҵ��ϼ���.

    void FixedUpdate()
    {
        if (playerCamera != null)
        {
            // UI ��Ҹ� ī�޶��� ��ġ�� ���� �̵���Ű��, ȸ������ �ʵ��� �����մϴ�.
            transform.position = playerCamera.transform.position;

            // UI ��Ұ� �׻� ī�޶� �ٶ󺸵��� ���� (���� ����)
            Vector3 lookPos = transform.position - playerCamera.transform.position;
            lookPos.y = 0; // ���Ʒ� ���� ȸ�� ����
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = rotation;

            // UI ��Ҹ� ȭ�� ���߾����� ��ġ��ŵ�ϴ�.
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.position = playerCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, playerCamera.nearClipPlane));
        }
    }
}
