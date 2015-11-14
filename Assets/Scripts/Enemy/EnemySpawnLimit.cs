using UnityEngine;
using System.Collections;

public class EnemySpawnLimit : MonoBehaviour 
{
	public int enemyLimit;
	int enemyNumber;
	
	void Start () 
	{
	
	}

	void Update () 
	{
		enemyNumber = GameObject.FindGameObjectsWithTag ("enemyHitDetect").Length;
	
		if (enemyNumber == enemyLimit)
		{
			gameObject.GetComponent<enemyspawner> ().enabled = false;
		} 
		else if (enemyNumber < enemyLimit) 
		{
			gameObject.GetComponent<enemyspawner> ().enabled = true;

		}
	}
}
