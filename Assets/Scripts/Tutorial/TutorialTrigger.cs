using UnityEngine;
using System.Collections;

public class TutorialTrigger : MonoBehaviour
{

    private IntroManager m_intromanager;

    public int tutTextToEnable;
    public bool enableAttack = false;
    public bool enableDash = false;
    public bool enableBlock = false;
    public bool loadLevel = false;
    public string levelToLoad;

    // Use this for initialization
    void Start()
    {
        m_intromanager = FindObjectOfType<IntroManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void TriggerActions()
    {
        this.gameObject.GetComponent<Collider>().enabled = false;
        m_intromanager.PerformIntroActions(tutTextToEnable);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && enableAttack == true)
        {
            TriggerActions();
            // m_intromanager.SetAttack(true);
        }

        else if (other.tag == "Player" && enableDash == true)
        {
            TriggerActions();
            //  m_intromanager.SetDash(true);
        }

        else if (other.tag == "Player" && loadLevel == true)
        {
            Application.LoadLevel(levelToLoad);
        }

        else if (other.tag == "Player")
        {
            TriggerActions();
        }

        else
        {
            Debug.Log(other);
        }
    }
}
