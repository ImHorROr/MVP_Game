using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Easy2DPlayerMovement
{
    public class MobileControlsScript : MonoBehaviour
    {
        /*
         * =====================================================
           This class handles all the mobile / virtual control interactions
         * =====================================================
         */
        [Tooltip("The player object within the scene")]
        [SerializeField] GameObject player = null;

        [SerializeField]
        GameObject buttons = null;

        InputManager playerInputManager = null;

        internal bool isLeftBtnDown;
        internal bool isRightBtnDown;
        internal bool isPressed_B;
        internal bool isPressed_A;

        // ====================================================
        private void Awake()
        {
            //if the player has not been assigned in the inspector, try to find it though other means
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                if (player == null)
                {
                    Debug.Log("No Player game object can be found");
                }
            }
        }

        // ====================================================
        private void Start()
        {
            if (player != null)
            {
                playerInputManager = player.GetComponent<InputManager>();
                playerInputManager.mobileControls = this;
            }
        }

        // ====================================================
        private void Update()
        {
            //hide the mobile buttons with Tab Key
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                buttons.SetActive(false);
            }
        }

        // ====================================================
        // Mobile Controls 
        public void OnPressLeft()
        {
            isLeftBtnDown = true;
        }

        // ====================================================
        public void OnReleaseLeft()
        {
            isLeftBtnDown = false;
        }

        // ====================================================
        public void OnPressRight()
        {
            isRightBtnDown = true;
        }

        // ====================================================
        public void OnReleaseRight()
        {
            isRightBtnDown = false;
        }

        // ====================================================
        public void OnPress_B()
        {
            isPressed_B = true;
        }

        // ====================================================
        public void OnRelease_B()
        {
            isPressed_B = false;
        }

        // ====================================================
        public void OnPress_A()
        {
            isPressed_A = true;
            if (playerInputManager != null)
            {
                playerInputManager.onJumpPressed();
            }
        }

        // ====================================================
        public void OnRelease_A()
        {
            isPressed_A = false;
            if (playerInputManager != null)
            {
                playerInputManager.onJumpReleased();
            }
        }

    }
}
