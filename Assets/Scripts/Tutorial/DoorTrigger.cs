using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour
{

    [SerializeField]
    private GameObject[] m_triggerableObjects;
    [SerializeField]
    private GameObject[] m_enemiestospawn;

    private int tutorialCount;

    public int tutorialToUnlock;

    public bool spawnEnemies;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        tutorialCount = FindObjectOfType<IntroManager>().tutorialCounter - 1;

        if (other.tag == "Player" && tutorialCount == tutorialToUnlock)
        {
            print("Player activated door");
            for (int i = 0; i < m_triggerableObjects.Length; i++)
            {
                m_triggerableObjects[i].SendMessage("ActivatePlatform");
            }

            if(spawnEnemies)
            {
                for (int i = 0; i < m_enemiestospawn.Length; i++)
                {
                    m_enemiestospawn[i].SetActive(true);
                }
            }
        }
    }
}
