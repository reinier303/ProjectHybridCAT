using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScenery : MonoBehaviour
{
    [SerializeField]
    public Transform LeftController;
    [SerializeField]
    public Transform RightController;

    public List<GameObject> sceneryObjects = new List<GameObject>();
    public List<GameObject> lights = new List<GameObject>();
    private List<GameObject> randomScenery = new List<GameObject>();

    public float RangeFactorX;
    public float RangeFactorY;
    public float RangeFactorZ;

    public static ChangeScenery Instance;


    private void Awake()
    {
        Instance = this;
        foreach (GameObject foundObject in GameObject.FindGameObjectsWithTag("Scenery"))
        {
            if(!foundObject.GetComponent<Scenery>())
            {
                foundObject.AddComponent(typeof(Scenery));
            }
            Scenery sceneryScript = foundObject.GetComponent<Scenery>();
            sceneryScript.controllerL = LeftController;
            sceneryScript.controllerR = RightController;
            sceneryScript.RangeFactorX = RangeFactorX;
            sceneryScript.RangeFactorY = RangeFactorY;
            sceneryScript.RangeFactorZ = RangeFactorZ;

            sceneryObjects.Add(foundObject);

            sceneryScript.Initialize();

        }
        foreach (GameObject foundObject in GameObject.FindGameObjectsWithTag("Lights"))
        {
            if (!foundObject.GetComponent<Scenery>())
            {
                foundObject.AddComponent(typeof(Scenery));
            }
            Scenery sceneryScript = foundObject.GetComponent<Scenery>();
            sceneryScript.controllerL = LeftController;
            sceneryScript.controllerR = RightController;
            sceneryScript.RangeFactorZ = RangeFactorZ;

            lights.Add(foundObject);

            sceneryScript.Initialize();

        }
        GetRandomScenery();
    }

    // Update is called once per frame
    private void Update()
    {
        foreach (GameObject sObject in sceneryObjects)
        {
            Scenery sceneryScript = sObject.GetComponent<Scenery>();
            sceneryScript.ChangeMaterialColorController();
            sceneryScript.ChangeMateriaTiling();
        }

        foreach (GameObject light in lights)
        {
            Scenery sceneryScript = light.GetComponent<Scenery>();
            sceneryScript.ChangeLights();
        }
        //float vertical = Input.GetAxis("Vertical");

        /*
        else
        {
            foreach (GameObject sObject in sceneryObjects)
            {
                Scenery sceneryScript = sObject.GetComponent<Scenery>();
                sceneryScript.ChangeMaterialColor(false);
            }
        }*/

    }

    private void GetRandomScenery()
    {
        randomScenery.Clear();
        foreach (GameObject scenery in sceneryObjects)
        {
            if(Random.Range(0, 101) < Random.Range(60, 90))
            {
                randomScenery.Add(scenery);
            }
        }
    }
}
