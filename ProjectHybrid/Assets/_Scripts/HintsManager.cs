using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HintsManager : MonoBehaviour
{
    public GameObject ControllerL;
    public GameObject ControllerR;
    public Text IntroFeedbackTextField;
    public string IntroFeedbackTextString;


    private bool activateText = false;

    public void Start()
    {

    }

    private void FixedUpdate()
    {
        if(ControllerL.transform.hasChanged || ControllerR.transform.hasChanged)
        {
            if(!activateText)
                StartCoroutine(ShowText(1f));
        }
    }

    private IEnumerator ShowText(float time)
    {
        IntroFeedbackTextField.text = IntroFeedbackTextString;
        yield return new WaitForSeconds(time);
        activateText = true;

    }
}
