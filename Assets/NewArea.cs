using UnityEngine;
using System.Collections;

public class NewArea : MonoBehaviour {

	public GameObject[] spawners;

	public GameObject previousAreaBlockade;

	public GameObject newAreaBlockade;

	void Awake()
	{
		previousAreaBlockade.SetActive(false);
		newAreaBlockade.SetActive (false);

		for (var i = 0; i < spawners.Length; i++) 
		{
				spawners[i].SetActive(false);
		}
	}



void OnTriggerEnter(Collider spawnZone)
	{
		if(spawnZone.gameObject.tag == "Player")
		{
			previousAreaBlockade.SetActive(true);
			newAreaBlockade.SetActive (true);
			for (var i = 0; i < spawners.Length; i++) 
			{
				print ("this is now spawning enemies in a new area");
				spawners[i].SetActive(true);
				Destroy (gameObject);

			}
	}
	}
}