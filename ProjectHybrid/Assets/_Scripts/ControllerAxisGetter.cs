using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAxisGetter : MonoBehaviour
{
    private Vector3 startPosition;
    
    //Position of controller relative to startPosition
    private Vector3 RelativePosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        //RelativePosition = new Vector3(transform.localPosition.x);
    }
}
