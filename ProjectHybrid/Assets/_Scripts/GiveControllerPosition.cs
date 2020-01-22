using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Bas
{
    public class GiveControllerPosition : MonoBehaviour
    {
        private SteamVR_TrackedObject trackedObj;

        private void Awake()
        {
            trackedObj = GetComponent<SteamVR_TrackedObject>();
        }

        private void FixedUpdate()
        {
            if(trackedObj.transform.hasChanged)
                Globals.OnControllerPositionUpdateHandler(trackedObj.transform.localPosition);
        }
    }
}
