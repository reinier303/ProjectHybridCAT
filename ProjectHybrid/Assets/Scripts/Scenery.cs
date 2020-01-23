using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenery : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Color StartColor;
    private float currentValue;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        StartColor = meshRenderer.material.color;
        currentValue = 0;
    }

    public void ChangeMaterialColor(bool positive)
    {
        Color currentColor = meshRenderer.material.color;
        float randomValueR = Random.Range(-0.015f, 0.015f);
        float randomValueG = Random.Range(-0.015f, 0.015f);
        float randomValueB = Random.Range(-0.015f, 0.015f);

        //Change currentValue to know where in the process we are.
        if(positive && currentValue < 1)
        {
            currentValue += 0.002f;
        }
        if (!positive && currentValue > -1)
        {
            currentValue -= 0.002f;
        }

        //Change color depending on where in the process we are.


        //Backwards: Change value according to difference from start to current value.
        
        float differenceSteps;

        if (!positive && currentValue > 0)
        {
            differenceSteps = currentValue / 0.002f;
            meshRenderer.material.color = new Color(currentColor.r + (StartColor.r - currentColor.r) / differenceSteps,
                                                    currentColor.g + (StartColor.g - currentColor.g) / differenceSteps,
                                                    currentColor.b + (StartColor.b - currentColor.b) / differenceSteps, currentColor.a);
        }
        if(positive && currentValue < 0)
        {
            differenceSteps = currentValue / -0.002f;
            meshRenderer.material.color = new Color(currentColor.r + (StartColor.r - currentColor.r) / differenceSteps,
                                                    currentColor.g + (StartColor.g - currentColor.g) / differenceSteps,
                                                    currentColor.b + (StartColor.b - currentColor.b) / differenceSteps, currentColor.a);
        }

        //Forwards: Change value at random.
        if (positive && currentValue < 1 && currentValue > 0)
        {
            meshRenderer.material.color = new Color(currentColor.r + randomValueR, currentColor.g + randomValueG, currentColor.b + randomValueB, currentColor.a);
        }
        if (!positive && currentValue > -1 && currentValue < 0)
        {
            meshRenderer.material.color = new Color(currentColor.r + randomValueR, currentColor.g + randomValueG, currentColor.b + randomValueB, currentColor.a);
        }
        print(currentValue);

    }
}
