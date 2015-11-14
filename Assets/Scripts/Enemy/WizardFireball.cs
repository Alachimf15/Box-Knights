using UnityEngine;
using System.Collections;

public class WizardFireball : MonoBehaviour {

    Transform target;

    public bool master;

    public float fireballSpeed;
    

    // Use this for initialization
    void Start () {
        print("fireball created");
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(target);
    }
	
	// Update is called once per frame
	void Update () {
        if (master == false)
        {
            transform.position += transform.forward * (Time.deltaTime * fireballSpeed);
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Terrain")
        {
            Debug.Log(other.gameObject.tag);
            Destroy(this.gameObject);
        }
    }
}
