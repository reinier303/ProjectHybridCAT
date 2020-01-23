using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScenery : MonoBehaviour
{
    private List<GameObject> sceneryObjects = new List<GameObject>();
    private List<GameObject> randomScenery = new List<GameObject>();

    private void Start()
    {
        foreach(GameObject foundObject in GameObject.FindGameObjectsWithTag("Scenery"))
        {
            sceneryObjects.Add(foundObject);
        }
        GetRandomScenery();
    }

    // Update is called once per frame
    private void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        if(vertical > 0)
        {
            foreach (GameObject sObject in sceneryObjects)
            {
                Scenery sceneryScript = sObject.GetComponent<Scenery>();
                sceneryScript.ChangeMaterialColor(true);
            }
        }
        if (vertical < 0)
        {
            foreach (GameObject sObject in sceneryObjects)
            {
                Scenery sceneryScript = sObject.GetComponent<Scenery>();
                sceneryScript.ChangeMaterialColor(false);
            }
        }

    }

    private void GetRandomScenery()
    {
        randomScenery.Clear();
        Debug.Log(sceneryObjects.Count);
        foreach (GameObject scenery in sceneryObjects)
        {
            if(Random.Range(0, 101) < Random.Range(60, 90))
            {
                randomScenery.Add(scenery);
            }
        }
        Debug.Log(randomScenery.Count);
    }
}
