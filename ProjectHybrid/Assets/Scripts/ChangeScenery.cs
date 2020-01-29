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
    public List<GameObject> Audio = new List<GameObject>();
    public List<GameObject> DistortionObjects = new List<GameObject>();
    public List<GameObject> Particles = new List<GameObject>();


    private List<GameObject> randomScenery = new List<GameObject>();

    public float RangeFactorX;
    public float RangeFactorY;
    public float RangeFactorZ;

    public AudioSource Left, Right;

    public static ChangeScenery Instance;

    public MeshRenderer tripMesh;

    public float FriendTransparency;
    public bool LXAxisSweet, LYAxisSweet, LZAxisSweet, RXAxisSweet, RYAxisSweet, RZAxisSweet;


    private void Awake()
    {
        Instance = this;
        LXAxisSweet = false;
        LYAxisSweet = false;
        LZAxisSweet = false;
        RXAxisSweet = false;
        RYAxisSweet = false;
        RZAxisSweet = false;
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
            sceneryScript.RangeFactorX = RangeFactorX;
            sceneryScript.RangeFactorY = RangeFactorY;
            sceneryScript.RangeFactorZ = RangeFactorZ;

            lights.Add(foundObject);

            sceneryScript.Initialize();

        }

        foreach (GameObject foundObject in GameObject.FindGameObjectsWithTag("Audio"))
        {
            if (!foundObject.GetComponent<Scenery>())
            {
                foundObject.AddComponent(typeof(Scenery));
            }
            Scenery sceneryScript = foundObject.GetComponent<Scenery>();
            sceneryScript.controllerL = LeftController;
            sceneryScript.controllerR = RightController;
            sceneryScript.RangeFactorX = RangeFactorX;
            sceneryScript.RangeFactorY = RangeFactorY;
            sceneryScript.RangeFactorZ = RangeFactorZ;

            sceneryScript.Left = Left;
            sceneryScript.Right = Right;

            Audio.Add(foundObject);

            sceneryScript.Initialize();

        }

        foreach (GameObject foundObject in DistortionObjects)
        {
            if (!foundObject.GetComponent<Scenery>())
            {
                foundObject.AddComponent(typeof(Scenery));
            }
            Scenery sceneryScript = foundObject.GetComponent<Scenery>();
            sceneryScript.controllerL = LeftController;
            sceneryScript.controllerR = RightController;
            sceneryScript.RangeFactorX = RangeFactorX;
            sceneryScript.RangeFactorY = RangeFactorY;
            sceneryScript.RangeFactorZ = RangeFactorZ;

            sceneryScript.Left = Left;
            sceneryScript.Right = Right;

            sceneryScript.Initialize();

        }

        foreach (GameObject foundObject in Particles)
        {
            if (!foundObject.GetComponent<Scenery>())
            {
                foundObject.AddComponent(typeof(Scenery));
            }
            Scenery sceneryScript = foundObject.GetComponent<Scenery>();
            sceneryScript.controllerL = LeftController;
            sceneryScript.controllerR = RightController;
            sceneryScript.RangeFactorX = RangeFactorX;
            sceneryScript.RangeFactorY = RangeFactorY;
            sceneryScript.RangeFactorZ = RangeFactorZ;

            sceneryScript.Left = Left;
            sceneryScript.Right = Right;

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
        }

        foreach (GameObject light in lights)
        {
            Scenery sceneryScript = light.GetComponent<Scenery>();
            sceneryScript.ChangeLights();
        }

        foreach (GameObject audio in Audio)
        {
            Scenery sceneryScript = audio.GetComponent<Scenery>();
            sceneryScript.ChangeSoundLX();
            sceneryScript.ChangeSoundRZ();
        }
        foreach (GameObject distortion in DistortionObjects)
        {
            Scenery sceneryScript = distortion.GetComponent<Scenery>();
            sceneryScript.ChangeMateriaTiling();
        }
        foreach (GameObject particle in Particles)
        {
            Scenery sceneryScript = particle.GetComponent<Scenery>();
            sceneryScript.ChangeParticles();
        }
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
