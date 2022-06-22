using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Easy2DPlayerMovement
{
    public class CameraSmoothFollow : MonoBehaviour
    {
        [SerializeField] bool followX = true;
        [SerializeField] bool followY = false;
        [SerializeField] float topLimit = 50;
        [SerializeField] float bottomLimit = 0;
        [SerializeField] public Transform target = null;
        Vector3 target_Offset;
        Vector3 camStartPos;

        private void Start()
        {
            if (target == null)
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
            }

            camStartPos = transform.position;
            target_Offset = transform.position - target.position;
        }

        //if the player has been assigned, track it
        void Update()
        {
            if (target)
            {
                Vector3 targPos = target.position;
                targPos.z = camStartPos.z;

                //check which axis to follow on
                if (!followY)
                {
                    targPos.y = camStartPos.y;
                }
                if (!followX)
                {
                    targPos.x = camStartPos.x;
                }

                if(targPos.y < bottomLimit)
                {
                    targPos.y = bottomLimit;
                }
                else if (targPos.y > topLimit)
                {
                    targPos.y = topLimit;
                }
                //update the camera position
                transform.position = Vector3.Lerp(transform.position, targPos, 0.1f);
            }
            else
            {
                Debug.LogWarning("The player game object has not been assigned on the Camera Follow Script");
            }
        }
    }

}

