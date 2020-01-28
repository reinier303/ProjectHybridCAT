using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bas;

public class FissaExample : MonoBehaviour
{
    public List<GameObject> DistortianObjects;
    public AudioClip FissaMusicClip;
    public AudioSource FissaAudioSource;
    public List<Transform> DancePositions;
    public List<GameObject> Dancers;

    public void Start()
    {
        Globals.OnFissaInitializeHandler += Init;
    }
    
    public void Init()
    {
        GetComponent<ChangeScenery>().enabled = false;
        FissaAudioSource.clip = FissaMusicClip;
        FissaAudioSource.Play();
        FissaAudioSource.GetComponent<AudioProcessor>().enabled = true;
        //Select the instance of AudioProcessor and pass a reference
        //to this object
        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        //processor.onBeat.AddListener(onOnbeatDetected);
        processor.onSpectrum.AddListener(onSpectrum);

        for(int index = 0; index < DancePositions.Count; index++)
        {
            if (index > Dancers.Count) return;
            Dancers[index].transform.position = DancePositions[index].position;
        }
      
    }

    //this event will be called every time a beat is detected.
    //Change the threshold parameter in the inspector
    //to adjust the sensitivity
    void onOnbeatDetected()
    {
        foreach(GameObject obj in DistortianObjects)
        {
            float scaleX = Mathf.Cos(Time.time) * 3f + 1;
            float scaleY = Mathf.Sin(Time.time) * 3f + 1;
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
            foreach (GameObject obj in DistortianObjects)
            {
                float scaleX = Mathf.Cos(Time.time) * 4f + 1;
                float scaleY = Mathf.Sin(Time.time) * 4f + 1;
                obj.GetComponent<Renderer>().material.mainTextureScale = new Vector2(scaleX, scaleY);
            }
        }

    }
}
