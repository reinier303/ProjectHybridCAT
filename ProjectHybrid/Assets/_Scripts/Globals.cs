using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bas
{
    public static class Globals
    {
        public delegate void OnControllerPositionUpdate(Vector3 position);
        public static OnControllerPositionUpdate OnControllerPositionUpdateHandler;
    }
}

