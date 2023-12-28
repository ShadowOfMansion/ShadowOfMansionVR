using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Autohand.Demo {

    [HelpURL("https://app.gitbook.com/s/5zKO0EvOjzUDeT2aiFk3/auto-hand/controller-input")]
    public class XRHandPlayerControllerLink : MonoBehaviour{
        public XRHandControllerLink moveController;  //left
        public XRHandControllerLink turnController;  //right
        public AutoHandPlayer player;

        [Header("Input")]
        public Common2DAxis moveAxis;
        public Common2DAxis turnAxis;

        bool isPressed = false;
        bool wasPressed = false;

        void Update(){
            player.Move(moveController.GetAxis2D(moveAxis));
            player.Turn(turnController.GetAxis2D(turnAxis).x);
        }
        void FixedUpdate(){
            player.Move(moveController.GetAxis2D(moveAxis));

            wasPressed = isPressed;

            // ���� ��Ʈ�ѷ� menu ��ư == ���� �Ͻ�����
            if (moveController.ButtonPressed(CommonButton.menuButton))
            {
                isPressed = true;
                if (isPressed && !wasPressed)
                {
                    if (player.useMovement)
                    {
                        player.useMovement = false;

                        // �Ͻ����� UI ����

                    }
                    else
                    {
                        // �Ͻ����� UI ����


                        player.useMovement = true;
                    }
                }
            }
            // ������ ��Ʈ�ѷ� A ��ư == �ɱ�
            else if (turnController.ButtonPressed(CommonButton.primaryButton))
            {
                isPressed = true;
                if (isPressed && !wasPressed)
                {
                    if (player.crouching)
                        player.crouching = false;
                    else
                        player.crouching = true;
                }
            }
            // ������ ��Ʈ�ѷ� B ��ư == ���帮��
            else if (turnController.ButtonPressed(CommonButton.secondaryButton))
            {
                isPressed = true;
                if (isPressed && !wasPressed)
                {
                    if (player.isprone)
                        player.isprone = false;
                    else
                        player.isprone = true;
                }
            }
            else
            {
                isPressed = false;
            }
        }
    }
}