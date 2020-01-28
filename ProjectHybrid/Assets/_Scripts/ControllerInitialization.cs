using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInitialization : MonoBehaviour
{
    public List<GameObject> ControllerBoxes;

    private void Start()
    {
        foreach(GameObject obj in ControllerBoxes)
        {
            obj.GetComponent<Renderer>().material.mainTextureScale = new Vector2(1, 1);
        }
    }
}
