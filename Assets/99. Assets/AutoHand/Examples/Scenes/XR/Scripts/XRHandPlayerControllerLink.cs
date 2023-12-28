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

            // 왼쪽 컨트롤러 menu 버튼 == 게임 일시정지
            if (moveController.ButtonPressed(CommonButton.menuButton))
            {
                isPressed = true;
                if (isPressed && !wasPressed)
                {
                    if (player.useMovement)
                    {
                        player.useMovement = false;

                        // 일시정지 UI 띄우기

                    }
                    else
                    {
                        // 일시정지 UI 끄기


                        player.useMovement = true;
                    }
                }
            }
            // 오른쪽 컨트롤러 A 버튼 == 앉기
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
            // 오른쪽 컨트롤러 B 버튼 == 엎드리기
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