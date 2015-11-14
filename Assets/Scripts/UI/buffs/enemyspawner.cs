using UnityEngine;
using System.Collections.Generic;
using System.Collections;
// Alexandru Achim
// Script for spawning the enemies
// 05/05/2015

public class enemyspawner : MonoBehaviour 

{
	bool isSpawning = false;
	[SerializeField]
	private float minTime = 5.0f;	// minimum time of enemy spawning
	[SerializeField]
	private float maxTime = 10.0f;	// maximum time of enemy spawning
	[SerializeField]
	private GameObject[] enemyPrefab;

	private List <GameObject> enemyList = new List<GameObject>();

	private int enemiesSpawned;
	public int enemyLimit;
	public int totalEnemies;

	public GameObject blocker;

	public GameObject enemyCounter;

	public string spawnerAnim;
	
	void Start () 
	{
		isSpawning = false;

		//GameObject[] tempEnemyArray = GameObject.FindGameObjectsWithTag ("enemyHitDetect");

		//for(int i = 0; i < tempEnemyArray.Length; ++i)
		//{
		//	enemyList.Add(tempEnemyArray[i]);
		//	enemiesSpawned ++;
		//}

		if (blocker != null) {
			blocker.GetComponent<blockers> ().enemies.Add (this.gameObject);
			print ("spawners have been added to blocker");

		}
	}

/// <summary>
/// Update this instance.
/// </summary>
	void Update () 
	{
		EnemyCounter ();
		if(enemyList.Count < enemyLimit)
		{
			//Spawns one enemy at a time.
			if (!isSpawning)
			{
				isSpawning = true;
				int enemyIndex = Random.Range (0, enemyPrefab.Length);
				StartCoroutine (SpawnEnemy (enemyIndex, Random.Range (minTime, maxTime)));


			} 
		}
		else
		{
			for(int i = 0; i < enemyList.Count; ++i)
			{
				if(enemyList[i] == null)
				{
					enemyList.RemoveAt(i);
					--i;
				}
			}
		}

		if (enemiesSpawned == totalEnemies) 
		{
			if (blocker != null) {
				blocker.GetComponent<blockers> ().enemies.Remove(gameObject);
				
			}
			Destroy (gameObject);

		}
	}

	void EnemyCounter()
	{

		enemyCounter.GetComponent<TextMesh>().text = (totalEnemies - enemiesSpawned).ToString() + " enemies left";
	}


	IEnumerator SpawnEnemy(int index, float seconds)
	{
		GameObject newEnemy = Instantiate(enemyPrefab[index], transform.position, transform.rotation)as GameObject;
		enemyList.Add (newEnemy);
		enemiesSpawned++;
		print (enemiesSpawned);
		GetComponent<Animation> ().Play (spawnerAnim);
		if (blocker != null) {
			blocker.GetComponent<blockers> ().enemies.Add (newEnemy);
			newEnemy.GetComponentInChildren<enemyHealth>().blocker = this.blocker;
		}


		yield return new WaitForSeconds (seconds);								// Pauses coroutine
				
		// Once an enemy is spawned a new enemy spawn timer begins counting down.
		GetComponent<Animation> ().Stop (spawnerAnim);
		isSpawning = false;
	}


}