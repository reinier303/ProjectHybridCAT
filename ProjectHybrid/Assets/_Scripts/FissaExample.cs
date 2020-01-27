using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FissaExample : MonoBehaviour
{
    public List<GameObject> DistortianObjects;

    void Start()
    {
        //Select the instance of AudioProcessor and pass a reference
        //to this object
        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        //processor.onBeat.AddListener(onOnbeatDetected);
        processor.onSpectrum.AddListener(onSpectrum);
    }

    //this event will be called every time a beat is detected.
    //Change the threshold parameter in the inspector
    //to adjust the sensitivity
    void onOnbeatDetected()
    {
        foreach(GameObject obj in DistortianObjects)
        {
            float scaleX = Mathf.Cos(Time.time) * 0.5f + 1;
            float scaleY = Mathf.Sin(Time.time) * 0.5f + 1;
            obj.GetComponent<Renderer>().material.mainTextureScale = new Vector2(scaleX, scaleY);
        }
        Debug.Log("Beat!!!");
    }

    //This event will be called every frame while music is playing
    void onSpectrum(float[] spectrum)
    {
        //The spectrum is logarithmically averaged
        //to 12 bands

        for (int i = 0; i < spectrum.Length; ++i)
        {
            Vector3 start = new Vector3(i, 0, 0);
            Vector3 end = new Vector3(i, spectrum[i], 0);

            Debug.DrawLine(start, end);
            foreach (GameObject obj in DistortianObjects)
            {
                float scaleX = Mathf.Cos(Time.time) * 2f + 1;
                float scaleY = Mathf.Sin(Time.time) * 2f + 1;
                obj.GetComponent<Renderer>().material.mainTextureScale = new Vector2(scaleX, scaleY);
            }
        }

    }
}
