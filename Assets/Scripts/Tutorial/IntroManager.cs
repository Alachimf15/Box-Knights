using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    //public List<GameObject> introTriggerList = new List<GameObject>();
    private Collider nextIntroTriggerCollider;
    public int tutorialCounter = 0;
    private bool tutorialTextDisplayed;
    private bool tutorialTextEnabled;
    public bool displayFirstTutorial;

    public UnityEngine.UI.Text continueText;

    public List<UnityEngine.UI.Text> tutorialText = new List<UnityEngine.UI.Text>();
    public Image bgimg;

    // Use this for initialization
    void Start()
    {
        //m_ricochetLine = LevelManager.instance.currentLine;
        //nextIntroTriggerCollider = introTriggerList[tutorialCounter].gameObject.GetComponent<Collider>();



        if (displayFirstTutorial == true)
        {
            PerformIntroActions(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
       /** 
       if (Input.GetMouseButtonDown(0) && tutorialTextDisplayed == true)
        {
            RemoveTutorialText(tutorialCounter);
        }
        **/
    }

    public void PerformIntroActions(int t)
    {
        Debug.Log(tutorialCounter + " " + t);
        if (tutorialCounter == t)
        {
            DisplayTutorialText(t);
        }
    }

    private void DisplayTutorialText(int t)
    {
        if (tutorialTextEnabled == true)
        {
            RemoveTutorialText(tutorialCounter - 1);
        }

        bgimg.enabled = true;
       // continueText.enabled = true;
        tutorialText[t].enabled = true;
        tutorialTextDisplayed = true;
        tutorialTextEnabled = true;
        tutorialCounter++;
    }

    private void RemoveTutorialText(int t)
    {
        bgimg.enabled = false;
       // continueText.enabled = false;
        tutorialText[t].enabled = false;
        tutorialTextDisplayed = false;
        tutorialTextEnabled = false;
        
    }

    public void ToggleTutorialText(bool textstate)
    {
        if (tutorialTextEnabled == true)
        {
            bgimg.enabled = textstate;
            continueText.enabled = textstate;
            tutorialText[tutorialCounter].enabled = textstate;
            tutorialTextDisplayed = textstate;
        }
    }
}
