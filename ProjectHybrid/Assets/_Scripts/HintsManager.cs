using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Bas;

[System.Serializable]
public class Hint
{
    [SerializeField]
    public AudioClip VoiceLine;
    [SerializeField]
    public string HintText;
    [SerializeField]
    public float TimeToWait;
    
}

public class HintsManager : MonoBehaviour
{
    public GameObject ControllerL;
    public GameObject ControllerR;
    public Text IntroFeedbackTextField;
    public string IntroFeedbackTextString;
    public AudioSource VoiceLineSource;
    public List<Hint> Hints;
    public int hintIndex = 1;

    public int FeedbackTime = 30;
    private bool activateText = false;

    public void Start()
    {

    }

    private void FixedUpdate()
    {
        if (ControllerL.transform.hasChanged || ControllerR.transform.hasChanged)
        {
            if (!activateText)
                StartCoroutine(ShowText(Hints[hintIndex].VoiceLine, Hints[hintIndex].HintText, Hints[hintIndex].TimeToWait));
        }
        else
        {
            if (!activateText)
            {
                FeedbackTime--;
                if (FeedbackTime < 0)
                {
                    StartCoroutine(ShowText(Hints[0].VoiceLine, Hints[0].HintText, Hints[0].TimeToWait));
                }
            }
        }

    }

    private IEnumerator ShowText(AudioClip voiceLine, string txt, float time)
    {
        activateText = true;
        hintIndex += 1;
        if (voiceLine != null)
        {
            VoiceLineSource.clip = voiceLine;
            VoiceLineSource.Play();
        }
        IntroFeedbackTextField.text = txt;
        yield return new WaitForSeconds(time);
        //Globals.OnFissaInitializeHandler();
        if (Hints.Count > hintIndex)
            StartCoroutine(ShowText(Hints[hintIndex].VoiceLine, Hints[hintIndex].HintText, Hints[hintIndex].TimeToWait));
    }
}
