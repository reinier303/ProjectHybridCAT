using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenery : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Light light;

    [SerializeField]
    private float speedFactor = 0.003f;
    [SerializeField]
    public Transform controllerR, controllerL;

    public Vector2 RZAxis = new Vector2(0, 2);

    //Lights
    private float startIntensity;

    //Color
    int RGorB;
    private Color startColor;

    //Tiling
    private Vector2 startTiling;

    //Axis Info
    private float currentValueX;
    private float currentValueY;
    private float currentValueZ;

    public float RStartValueX;
    public float RStartValueY;
    public float RStartValueZ;

    public float RangeFactorX;
    public float RangeFactorY;
    public float RangeFactorZ;

    //Start     -0.52

    //POS -0.71

    //NEG - 0.16

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        light = GetComponent<Light>();
        if(light != null)
        {
            startIntensity = light.intensity;
        }

        if (meshRenderer != null)
        {
            startTiling = meshRenderer.material.mainTextureScale;

            startColor = meshRenderer.material.color;
            RGorB = Random.Range(0, 3);
        }

        RStartValueX = controllerR.localPosition.x / RangeFactorX;
        RStartValueY = controllerR.localPosition.y / RangeFactorY;
        RStartValueZ = controllerR.localPosition.z / RangeFactorZ;
    }

    public void ChangeMaterialColorController()
    {
        Color currentColor = meshRenderer.material.color;
        float currentMetallic = meshRenderer.material.GetFloat("_Metallic");
        float currentSmoothness = meshRenderer.material.GetFloat("_Glossiness");

        float randomValueR = Random.Range(-0.015f, 0.015f);
        float randomValueG = Random.Range(-0.015f, 0.015f);
        float randomValueB = Random.Range(-0.015f, 0.015f);

        currentValueY = controllerR.localPosition.y / RangeFactorY;

        if(RGorB == 0)
        {
            meshRenderer.material.color = new Color(startColor.r + (currentValueY - RStartValueY), startColor.g, startColor.b, currentColor.a);
        }
        else if (RGorB == 1)
        {
            meshRenderer.material.color = new Color(startColor.r, startColor.g + (currentValueY - RStartValueY), startColor.b, currentColor.a);
        }
        else if(RGorB == 2)
        {
            meshRenderer.material.color = new Color(startColor.r, startColor.g, startColor.b + (currentValueY - RStartValueY), currentColor.a);
        }

        meshRenderer.material.SetFloat("_Metallic", currentMetallic + (0 - currentMetallic));
        meshRenderer.material.SetFloat("_Glossiness", currentMetallic + (0 - currentMetallic));
    }

    public void ChangeMateriaTiling()
    {
        float currentTilingX = meshRenderer.material.mainTextureScale.x;
        float currentTilingY = meshRenderer.material.mainTextureScale.y;
        Vector2 currentTiling = new Vector2(currentTilingX, currentTilingY);

        currentValueX = controllerR.localPosition.x / RangeFactorX;

        meshRenderer.material.mainTextureScale = new Vector2(startTiling.x + (currentValueX - RStartValueX), startTiling.y + (currentValueX - RStartValueX));
    }

    public void ChangeLights()
    {
        if(light == null)
        {
            Debug.Log("No light on object");
            return;
        }
        float currentIntensity = light.intensity;

        currentValueZ = controllerR.localPosition.z / RangeFactorZ;

        light.intensity = startIntensity + (currentValueZ - RStartValueZ);

    }

}
