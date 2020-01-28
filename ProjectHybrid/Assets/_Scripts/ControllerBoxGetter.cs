using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBoxGetter : MonoBehaviour
{
    public GameObject ControllerBox;
    public GameObject ControllerBox2;
    public GameObject[] ControllerModels;

    private void Start()
    {
        ControllerModels = GameObject.FindGameObjectsWithTag("Controller");
    }

    private void FixedUpdate()
    {
        foreach (var obj in ControllerModels)
        {
            if (obj.transform.childCount > 0) continue;
            if (Vector3.Distance(ControllerBox.transform.position, obj.transform.position) < 2f)
            {
                ControllerBox.transform.parent = obj.transform;
                ControllerBox.transform.position = new Vector3(0, 0, 0);
            }
            if(Vector3.Distance(ControllerBox2.transform.position, obj.transform.position) < 2f)
            {
                ControllerBox2.transform.parent = obj.transform;
                ControllerBox2.transform.position = new Vector3(0, 0, 0);
            }
        }
     }
}
