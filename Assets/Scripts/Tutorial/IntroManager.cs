using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    public List<GameObject> introTriggerList = new List<GameObject>();
    private Collider nextIntroTriggerCollider;
    private int tutorialCounter = 0;
    private int tutorialTextCount = 0;
    //private PlayerMovement playerMovement;
    private bool tutorialTextDisplayed;
    public bool displayFirstTutorial;

    public List<UnityEngine.UI.Text> tutorialText = new List<UnityEngine.UI.Text>();
    public Image bgimg;

    private CharacterController playerController;

    // Use this for initialization
    void Start()
    {
        playerController = FindObjectOfType<CharacterController>();
        //playerMovement = playerController.GetComponent<PlayerMovement>();
        nextIntroTriggerCollider = introTriggerList[tutorialCounter].gameObject.GetComponent<Collider>();

        if (displayFirstTutorial == true)
        {
            DisplayTutorialText(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e") && tutorialTextDisplayed == true)
        {
            RemoveTutorialText(tutorialTextCount);
        }
    }

    public void PerformIntroActions(bool enabMech)
    {
        if(tutorialCounter == 0)
        {
            if(enabMech == true)
            {
                // add code for enabling mechanic here
            }

            DisplayTutorialText(tutorialTextCount);
            tutorialCounter++;
            nextIntroTriggerCollider = introTriggerList[tutorialCounter].gameObject.GetComponent<Collider>();
            nextIntroTriggerCollider.enabled = true;
        }

        else if (tutorialCounter == 1)
        {
            DisplayTutorialText(tutorialTextCount);
            tutorialCounter++;
            nextIntroTriggerCollider = introTriggerList[tutorialCounter].gameObject.GetComponent<Collider>();
            nextIntroTriggerCollider.enabled = true;
        }

        else if (tutorialCounter == 2)
        {
            DisplayTutorialText(tutorialTextCount);
            tutorialCounter++;
            nextIntroTriggerCollider = introTriggerList[tutorialCounter].gameObject.GetComponent<Collider>();
            nextIntroTriggerCollider.enabled = true;
        }

        else if (tutorialCounter == 3)
        {
            DisplayTutorialText(tutorialTextCount);
            tutorialCounter++;
            nextIntroTriggerCollider = introTriggerList[tutorialCounter].gameObject.GetComponent<Collider>();
            nextIntroTriggerCollider.enabled = true;
        }

        else 
        {
            DisplayTutorialText(tutorialTextCount);
        }
    }

    private void DisplayTutorialText(int t)
    {
        bgimg.enabled = true;
        tutorialText[t].enabled = true;
        //playerMovement.SetMovement(false);
        tutorialTextDisplayed = true;
    }

    private void RemoveTutorialText(int t)
    {
        bgimg.enabled = false;
        tutorialText[t].enabled = false;
        //playerMovement.SetMovement(true);
        tutorialTextDisplayed = false;
        tutorialTextCount++;
    }
}
