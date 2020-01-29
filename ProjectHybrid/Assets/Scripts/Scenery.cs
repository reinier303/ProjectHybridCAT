using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenery : MonoBehaviour
{
    [SerializeField]
    private float FriendTransparency;

    private MeshRenderer meshRenderer;
    private Light light;
    private ParticleSystem particleSystem;

    [SerializeField]
    private float speedFactor = 0.003f;
    [SerializeField]
    public Transform controllerR, controllerL;
    public AudioSource Left, Right;


    public Vector2 RZAxis = new Vector2(0, 2);
    //Particle System
    private ParticleSystem.MinMaxCurve startEmmissionRate;

    //Sound
    private float startPitchL, startPitchR;
    private float startWetmix, startChorus;

    //Lights
    private float startIntensity;

    //Color
    int RGorB;
    private Color startColor;

    //Tiling
    private Vector2 startTiling;

    //Axis Info
    private float RcurrentValueX;
    private float RcurrentValueY;
    private float RcurrentValueZ;

    private float LcurrentValueX;
    private float LcurrentValueY;
    private float LcurrentValueZ;

    public float RStartValueX;
    public float RStartValueY;
    public float RStartValueZ;

    public float LStartValueX;
    public float LStartValueY;
    public float LStartValueZ;

    public float RangeFactorX;
    public float RangeFactorY;
    public float RangeFactorZ;


    public ChangeScenery changeScenery;

    public void Initialize()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        light = GetComponent<Light>();
        particleSystem = GetComponent<ParticleSystem>();
        changeScenery = ChangeScenery.Instance;

        if (particleSystem != null)
        {
            startEmmissionRate = particleSystem.emission.rateOverTime;
        }

        if (Left != null && Right != null)
        {
            Left.outputAudioMixerGroup.audioMixer.GetFloat("FlangeRate", out startPitchL);
            Right.outputAudioMixerGroup.audioMixer.GetFloat("Distortion", out startPitchR);
            Right.outputAudioMixerGroup.audioMixer.GetFloat("Wetmix", out startWetmix);
            Left.outputAudioMixerGroup.audioMixer.GetFloat("ChorusDepth", out startChorus);
        }

        if (light != null)
        {
            startIntensity = light.intensity;

        }
        if (light == null)
        {
            ChangeScenery.Instance.lights.Remove(gameObject);
        }

        if (meshRenderer != null)
        {
            if(meshRenderer.material.HasProperty("_Color"))
            {
                startColor = meshRenderer.material.color;
                RGorB = Random.Range(0, 3);
            }
            startTiling = meshRenderer.material.mainTextureScale;
        }
        if (meshRenderer == null)
        {
            ChangeScenery.Instance.sceneryObjects.Remove(gameObject);
        }

        RStartValueX = controllerR.localPosition.x / RangeFactorX;
        RStartValueY = controllerR.localPosition.y / RangeFactorY;
        RStartValueZ = controllerR.localPosition.z / RangeFactorZ;

        LStartValueX = controllerL.localPosition.x / RangeFactorX;
        LStartValueY = controllerL.localPosition.y / RangeFactorY;
        LStartValueZ = controllerL.localPosition.z / RangeFactorZ;
    }
    
    //Right Y Axis
    public void ChangeMaterialColorController()
    {
        Color currentColor = meshRenderer.material.color;
        float currentMetallic = meshRenderer.material.GetFloat("_Metallic");
        float currentSmoothness = meshRenderer.material.GetFloat("_Glossiness");

        float randomValueR = Random.Range(-0.015f, 0.015f);
        float randomValueG = Random.Range(-0.015f, 0.015f);
        float randomValueB = Random.Range(-0.015f, 0.015f);

        RcurrentValueY = controllerR.localPosition.y / RangeFactorY;

        if(RGorB == 0)
        {
            meshRenderer.material.color = new Color(startColor.r + (RcurrentValueY - RStartValueY), startColor.g, startColor.b, currentColor.a);
        }
        else if (RGorB == 1)
        {
            meshRenderer.material.color = new Color(startColor.r, startColor.g + (RcurrentValueY - RStartValueY), startColor.b, currentColor.a);
        }
        else if(RGorB == 2)
        {
            meshRenderer.material.color = new Color(startColor.r, startColor.g, startColor.b + (RcurrentValueY - RStartValueY), currentColor.a);
        }

        meshRenderer.material.SetFloat("_Metallic", currentMetallic + (0 - currentMetallic));
        meshRenderer.material.SetFloat("_Glossiness", currentMetallic + (0 - currentMetallic));

        CheckIfSweetSpot(RStartValueY, RcurrentValueY, RangeFactorY, changeScenery.RYAxisSweet, "RY");

    }

    //Left Y Axis
    public void ChangeMateriaTiling()
    {
        float currentTilingX = meshRenderer.material.mainTextureScale.x;
        float currentTilingY = meshRenderer.material.mainTextureScale.y;
        Vector2 currentTiling = new Vector2(currentTilingX, currentTilingY);

        LcurrentValueY = controllerL.localPosition.y / RangeFactorY;

        meshRenderer.material.mainTextureScale = new Vector2(startTiling.y + (LcurrentValueY - LStartValueY), startTiling.y + (LcurrentValueY - LStartValueY));

        CheckIfSweetSpot(LStartValueY, LcurrentValueY, RangeFactorY, changeScenery.LYAxisSweet, "LY");
    }

    //Right X Axis
    public void ChangeLights()
    {
        float currentIntensity = light.intensity;

        RcurrentValueX = controllerR.localPosition.x / RangeFactorX;

        light.intensity = startIntensity + (RcurrentValueX - RStartValueX);

        CheckIfSweetSpot(RStartValueX, RcurrentValueX, RangeFactorX, changeScenery.RXAxisSweet, "RX");
    }

    //Left X Axis
    public void ChangeSoundLX()
    {
        float currentPitchL = Left.pitch;
        float currentPitchR = Right.pitch;

        LcurrentValueX = controllerL.localPosition.x / RangeFactorX;

        Left.outputAudioMixerGroup.audioMixer.SetFloat("FlangeRate", startPitchL + (LcurrentValueX - LStartValueX));
        Left.outputAudioMixerGroup.audioMixer.SetFloat("FlangeDepth", startPitchL + (LcurrentValueX - LStartValueX));

        float currentDistortion;
        Right.outputAudioMixerGroup.audioMixer.GetFloat("Distortion", out currentDistortion);
        Right.outputAudioMixerGroup.audioMixer.SetFloat("Distortion", startPitchR - (LcurrentValueX - LStartValueX));
        //Right.pitch = startPitchR - ((LcurrentValueX - LStartValueX));

        CheckIfSweetSpot(LStartValueX, LcurrentValueX, RangeFactorX, changeScenery.LXAxisSweet, "LX");
    }

    //Right Z Axis
    public void ChangeSoundRZ()
    {
        RcurrentValueZ = controllerR.localPosition.z / RangeFactorZ;
        
        Right.outputAudioMixerGroup.audioMixer.SetFloat("Wetmix", startWetmix + (RcurrentValueZ - RStartValueZ));
        Left.outputAudioMixerGroup.audioMixer.SetFloat("ChorusDepth", startChorus - (RcurrentValueZ - RStartValueZ));

        float currentWetmix;
        Right.outputAudioMixerGroup.audioMixer.GetFloat("Wetmix", out currentWetmix);

        CheckIfSweetSpot(RStartValueZ, RcurrentValueZ, RangeFactorZ, changeScenery.RZAxisSweet, "RZ");
    }

    //Left Z Axis
    public void ChangeParticles()
    {
        LcurrentValueZ = controllerL.localPosition.z / RangeFactorZ;
        float currentEmmisionRate = particleSystem.emission.rateOverTime.constant;
        var emissionRate = particleSystem.emission.rateOverTime;

        //Unity Obsolete warning is not correct || this works instead of non-obsolete alternative.
        particleSystem.emissionRate = startEmmissionRate.constant + (LcurrentValueZ - LStartValueZ);

        CheckIfSweetSpot(LStartValueZ, LcurrentValueZ, RangeFactorZ, changeScenery.LZAxisSweet, "LZ");

    }

    private void CheckIfSweetSpot(float startValue, float currentValue, float rangeValue, bool axisSweet, string AxisBool)
    {
        if (currentValue < (-rangeValue / 10 + startValue) || currentValue > (rangeValue / 10 + startValue) && axisSweet)
        {
            switch (AxisBool)
            {
                case "LX":
                    {
                        if(changeScenery.LXAxisSweet)
                        {
                            changeScenery.ChangeTransparency(-1f / 6);
                            changeScenery.LXAxisSweet = false;
                        }
                        break;
                    }
                case "LY":
                    {
                        if (changeScenery.LYAxisSweet)
                        {
                            changeScenery.ChangeTransparency(-1f / 6);
                            changeScenery.LYAxisSweet = false;
                        }
                        break;
                    }
                case "LZ":
                    {
                        if (changeScenery.LZAxisSweet)
                        {
                            changeScenery.ChangeTransparency(-1f / 6);
                            changeScenery.LZAxisSweet = false;
                        }
                        break;
                    }
                case "RX":
                    {
                        if (changeScenery.RXAxisSweet)
                        {
                            changeScenery.ChangeTransparency(-1f / 6);
                            changeScenery.RXAxisSweet = false;
                        }
                        break;
                    }
                case "RY":
                    {
                        if (changeScenery.RYAxisSweet)
                        {
                            changeScenery.ChangeTransparency(-1f / 6);
                            changeScenery.RYAxisSweet = false;
                        }
                        break;
                    }
                case "RZ":
                    {
                        if (changeScenery.RZAxisSweet)
                        {
                            changeScenery.ChangeTransparency(-1f / 6);
                            changeScenery.RZAxisSweet = false;
                        }
                        break;
                    }
            }
        }
        else if (currentValue > (-rangeValue / 10 + startValue) && currentValue < (rangeValue / 10 + startValue) && !axisSweet)
        {
            changeScenery.ChangeTransparency(1f / 6);
            switch (AxisBool)
            {
                case "LX":
                    {
                        changeScenery.LXAxisSweet = true;
                        break;
                    }
                case "LY":
                    {
                        changeScenery.LYAxisSweet = true;
                        break;
                    }
                case "LZ":
                    {
                        changeScenery.LZAxisSweet = true;
                        break;
                    }
                case "RX":
                    {
                        changeScenery.RXAxisSweet = true;
                        break;
                    }
                case "RY":
                    {
                        changeScenery.RYAxisSweet = true;
                        break;
                    }
                case "RZ":
                    {
                        changeScenery.RZAxisSweet = true;
                        break;
                    }
            }
        }
    }
}
