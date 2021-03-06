﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenery : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Color StartColor;
    private float currentValue;
    [SerializeField]
    private float speedFactor = 0.003f;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        StartColor = meshRenderer.material.color;
        currentValue = 0;
    }

    public void ChangeMaterialColor(bool positive)
    {
        Color currentColor = meshRenderer.material.color;
        float currentMetallic = meshRenderer.material.GetFloat("_Metallic");
        float currentSmoothness = meshRenderer.material.GetFloat("_Glossiness");


        float randomValueR = Random.Range(-0.015f, 0.015f);
        float randomValueG = Random.Range(-0.015f, 0.015f);
        float randomValueB = Random.Range(-0.015f, 0.015f);

        //Change currentValue to know where in the process we are.
        if(positive && currentValue < 1)
        {
            currentValue += speedFactor;
        }
        if (!positive && currentValue > -1)
        {
            currentValue -= speedFactor;
        }

        //Change color depending on where in the process we are.


        //Backwards: Change value according to difference from start to current value.
        
        float differenceSteps;

        if (!positive && currentValue > 0)
        {
            differenceSteps = currentValue / speedFactor;
            meshRenderer.material.color = new Color(currentColor.r + (StartColor.r - currentColor.r) / differenceSteps,
                                                    currentColor.g + (StartColor.g - currentColor.g) / differenceSteps,
                                                    currentColor.b + (StartColor.b - currentColor.b) / differenceSteps, currentColor.a);
            meshRenderer.material.SetFloat("_Metallic", currentMetallic + (0 - currentMetallic) / differenceSteps);
            meshRenderer.material.SetFloat("_Glossiness", currentMetallic + (0 - currentMetallic) / differenceSteps);

        }
        if (positive && currentValue < 0)
        {
            differenceSteps = currentValue / -speedFactor;
            meshRenderer.material.color = new Color(currentColor.r + (StartColor.r - currentColor.r) / differenceSteps,
                                                    currentColor.g + (StartColor.g - currentColor.g) / differenceSteps,
                                                    currentColor.b + (StartColor.b - currentColor.b) / differenceSteps, currentColor.a);
            meshRenderer.material.SetFloat("_Metallic", currentMetallic + (0 - currentMetallic) / differenceSteps);
            meshRenderer.material.SetFloat("_Glossiness", currentMetallic + (0 - currentMetallic) / differenceSteps);
        }

        //Forwards: Change value at random.
        if (positive && currentValue < 1 && currentValue > 0)
        {
            meshRenderer.material.color = new Color(currentColor.r + randomValueR, currentColor.g + randomValueG, currentColor.b + randomValueB, currentColor.a);
            meshRenderer.material.SetFloat("_Metallic", currentMetallic + Random.Range(0.0015f, 0.0045f));
            meshRenderer.material.SetFloat("_Glossiness", currentMetallic + Random.Range(0.001f, 0.0025f));
        }
        if (!positive && currentValue > -1 && currentValue < 0)
        {
            meshRenderer.material.color = new Color(currentColor.r + randomValueR, currentColor.g + randomValueG, currentColor.b + randomValueB, currentColor.a);
            meshRenderer.material.SetFloat("_Metallic", currentMetallic + Random.Range(0.0015f, 0.0045f));
            meshRenderer.material.SetFloat("_Glossiness", currentMetallic + Random.Range(0.001f, 0.0025f));
        }
        print(currentValue);

    }
}
