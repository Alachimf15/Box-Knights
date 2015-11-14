using UnityEngine;
using System.Collections;

public class winConditions : MonoBehaviour 
{
	int EnemyCount;

	void Start () 
	{
		EnemyCount = GameObject.FindGameObjectsWithTag("enemy").Length;
		Debug.Log (EnemyCount + " enemies detected.");
	}	

	void OnTriggerEnter (Collider Win)
	{
		if (Win.tag == "Player")
	//EnemyCount = 
		//EnemyCount = GameObject.FindGameObjectsWithTag("enemy").Length;

		//if(EnemyCount == 0)
		{
			Application.LoadLevel(3);
		}
	}
}

