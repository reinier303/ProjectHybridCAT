using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Bas;

namespace Bas
{
    public class ControllerTracker : MonoBehaviour
    {
        public Vector3 LeftControllerPosition;
        public Vector3 RightControllerPosition;
        public GameObject leftController;
        public GameObject rightController;

        private void Start()
        {
            //Globals.OnControllerPositionUpdateHandler += UpdateControllerTransform;
        }

        private void FixedUpdate()
        {
            if (leftController.transform.hasChanged)
                LeftControllerPosition = leftController.transform.localPosition;

            if (rightController.transform.hasChanged)
                RightControllerPosition = rightController.transform.localPosition;
        }

        //Getter for controllerpositions defined by index
        public Vector3 GetControllerPosition(int controllerindex)
        {
            switch(controllerindex)
            {
                case 0:
                    return LeftControllerPosition;
                    break;
                case 1:
                    return RightControllerPosition;
                    break;
                default:
                    return LeftControllerPosition;
                    break;
            }
        }

        public void UpdateControllerTransform(Vector3 controllerPosition)
        {
            if (leftController.transform.localPosition == controllerPosition)
            {
                LeftControllerPosition = controllerPosition;
            }
            else if (rightController.transform.localPosition == controllerPosition)
            {
                RightControllerPosition = controllerPosition;
            }
        }
    }
}
 

