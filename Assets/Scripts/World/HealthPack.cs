using UnityEngine;
using System.Collections;

public class HealthPack : MonoBehaviour {

	public int healthPackValue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


void OnTriggerEnter(Collider health)
{
	if(health.GetComponent<Collider>().tag == "Player")
		{
			health.GetComponent<playerHealth>().currHealth += healthPackValue;
			Debug.Log ("the player has " + health.GetComponent<playerHealth>().currHealth);
			Destroy(gameObject);
		}
	}

}