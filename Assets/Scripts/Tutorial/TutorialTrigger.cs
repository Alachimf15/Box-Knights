using UnityEngine;
using System.Collections;

public class TutorialTrigger : MonoBehaviour {

    private IntroManager m_intromanager;

    public bool enableMechanic;

    // Use this for initialization
    void Start () {
        m_intromanager = FindObjectOfType<IntroManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player")
        {
            this.gameObject.GetComponent<Collider>().enabled = false;
            m_intromanager.PerformIntroActions(enableMechanic);
        }
    }
}
