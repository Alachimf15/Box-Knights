using UnityEngine;
using System.Collections;

//this is a script which will have the enemy track the player and attempt to hit him if he's in range of their attack radius
public class EnemyDoDamage : MonoBehaviour 
{
	public int[] timeToAttack;
	
	bool hasHit;
	
	bool isAttacking;
	
	bool playerInRange;
	
	bool trackingPlayer;
	
	public string[] enemyAttackAnimations;
	
	public string[] enemyOtherAnimations;
	
	public string findThisEnemyWeapon;
	
	public GameObject enemyWeapon;
	
	GameObject enemyHitDetect;
	
	public Transform target;
	
	Enemy FindEnemyScript;
	
	void Start () 
	{
		//finds the palyer's transform in order to follow him
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		
		FindEnemyScript = this.GetComponent<Enemy> ();
		
		enemyWeapon = transform.FindChild (findThisEnemyWeapon).gameObject;//arm_bicep_right/arm_forearm_right/Hand_Right/Mod_Weapon_SicklySabre").gameObject;
		
		//Debug.Log (enemyWeapon.name);
		
		FindEnemyScript.enabled = true;
	}
	
	void OnTriggerEnter(Collider other) 
	{
		//if the object that entered the attack radius is the player, then the player is in range to be attacked
		if (other.CompareTag ("Player"))
		{
			playerInRange = true;
			
			if(hasHit == false)
			{
				
				StartCoroutine(Attack (other.gameObject));
			}
			if(other.gameObject.tag == "weapon")
			{
				
				print ("got hit yo");
			}
			
		}
		
	}
	
	IEnumerator Attack(GameObject other)
	{
		//plays the attack animation
		enemyWeapon.GetComponent<enemyDamage>().hitPlayer = false;
		gameObject.GetComponent<Animation> ().CrossFade (enemyAttackAnimations [0], .2f);
		gameObject.GetComponent<Animation> ().PlayQueued (enemyAttackAnimations[1]);
		gameObject.GetComponent<Animation> ().PlayQueued (enemyAttackAnimations [2]);
		
		
		
		hasHit = true;
		
		
		
		
		yield return new WaitForSeconds (Random.Range (timeToAttack[0], timeToAttack[1]));
		
		hasHit = false;
		
		if(!playerInRange && hasHit == false)
		{
			FindEnemyScript.enabled = true;
		}
		else
		{
			float turnSpeed = 100f;
			
			transform.LookAt (target);
			StartCoroutine(Attack(other));
		}
	}
	
	
	
	void Update ()
	{
		
		
		if(enemyWeapon.GetComponent<enemyDamage>().hitPlayer == true||!GetComponent<Animation>().IsPlaying(enemyAttackAnimations[1]))
		{
			enemyWeapon.GetComponent<Collider>().enabled = false;
		}
		if(GetComponent<Animation>().IsPlaying(enemyAttackAnimations[1])&&(enemyWeapon.GetComponent<enemyDamage>().hitPlayer == false))
		{
			enemyWeapon.GetComponent<Collider>().enabled = true;
		}
		if (hasHit == true) 
		{
			FindEnemyScript.enabled = false;
			
		}
		if (FindEnemyScript.enabled == true) 
		{
			trackingPlayer = true;
		}
		else
		{
			trackingPlayer = false;
		}
		
		if(trackingPlayer == true)
		{
			
			gameObject.GetComponent <Animation>().CrossFade (enemyOtherAnimations[0], .1f);
		}
		
		else
		{
			gameObject.GetComponent <Animation>().Stop (enemyOtherAnimations[0]);
		}
		
	}
	
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			playerInRange = false;
		}
	}
	
	
	
}