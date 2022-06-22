using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Easy2DPlayerMovement
{
    public class InputManager : NetworkBehaviour
    {
        /*
         * =====================================================
           This is the input manager that listens to all the 
           button presses from keyboard and joysticks.
           The movement controller listens to this class to 
           determine player movement.
         * =====================================================
         */

        public Action onJumpPressed; // action set by the MovementManager
        public Action onJumpReleased; //action set by the MovementManager
        public Action onAttackPressed; //action set by the MovementManager
        public Action onAttackReleassed; //action set by the MovementManager

        internal bool isJumpPressed;
        internal bool isSprintPressed;
        internal bool isLeftPressed;
        internal bool isRightPressed;

        internal float xAxis; //controller and keyboard left and right movement axis
        internal MobileControlsScript mobileControls;

        // ====================================================
        void Update()
        {
            if (isLocalPlayer)
            {

                //Checks both joystick axis, as well as keyboard A and D, as well as Arrows Left and Right
                xAxis = Input.GetAxisRaw(Axis.HORIZONTAL);

                //check if pressing Left, Right or neither
                if (xAxis < 0 || (mobileControls != null && mobileControls.isLeftBtnDown))
                {
                    isLeftPressed = true;
                    isRightPressed = false;
                }
                else if (xAxis > 0 || (mobileControls != null && mobileControls.isRightBtnDown))
                {
                    isRightPressed = true;
                    isLeftPressed = false;
                }
                else
                {
                    isLeftPressed = false;
                    isRightPressed = false;
                }

                //==========================================
                //check if jump was pressed
                if (Input.GetButtonDown(InputType.JUMP))
                {
                    if (onJumpPressed != null)
                    {
                        onJumpPressed();
                    }
                }

                //check if jump was released
                if (Input.GetButtonUp(InputType.JUMP))
                {
                    if (onJumpReleased != null)
                    {
                        onJumpReleased();
                    }
                }

                //==========================================
                //check if jump was pressed
                if (Input.GetButtonDown(InputType.ATTACK))
                {
                    if (onAttackPressed != null)
                    {
                        onAttackPressed();
                    }
                }

                //check if jump was released
                if (Input.GetButtonUp(InputType.ATTACK))
                {
                    if (onAttackPressed != null)
                    {
                        onAttackPressed();
                    }
                }

                //check if jump is being held down
                if (Input.GetButton(InputType.JUMP) || (mobileControls != null && mobileControls.isPressed_A))
                {
                    isJumpPressed = true;
                }
                else
                {
                    isJumpPressed = false;
                }

                //check if spring button down
                if (Input.GetButton(InputType.SPRINT) || (mobileControls != null && mobileControls.isPressed_B))
                {
                    isSprintPressed = true;
                }
                else
                {
                    isSprintPressed = false;
                }
            }
        }
    }
}
