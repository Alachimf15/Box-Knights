using UnityEngine;
using System.Collections;

//this is a script which will have the enemy track the player and attempt to hit him if he's in range of their attack radius
public class WizardDoDamage : MonoBehaviour 
{
	public int timeToAttack;

	public float attackRange;

	bool hasHit;

	bool isAttacking;

	bool playerInRange;

	bool trackingPlayer;

	public string[] enemyAttackAnimations;

	public string[] enemyOtherAnimations;

	public string findThisEnemyWeapon;

	public GameObject enemyWeapon;

	GameObject enemyHitDetect;

	GameObject Player;

	public Transform target;

	Wizard FindEnemyScript;
	
	void Start () 
	{
		//finds the palyer's transform in order to follow him
		Player = GameObject.FindGameObjectWithTag ("Player");
		target = Player.transform;

		FindEnemyScript = this.GetComponent<Wizard> ();

		enemyWeapon = transform.FindChild (findThisEnemyWeapon).gameObject;//arm_bicep_right/arm_forearm_right/Hand_Right/Mod_Weapon_SicklySabre").gameObject;
		//enemyWeapon = transform.FindChild("enemyWeapon").gameObject;

		//Debug.Log (enemyWeapon.name);

		FindEnemyScript.enabled = true;
	}

	/**void OnTriggerEnter(Collider other) 
	{
		//if the object that entered the attack radius is the player, then the player is in range to be attacked
		if (other.gameObject.tag == "Player")
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

	}**/

	IEnumerator Attack(GameObject Player)
	{
		//plays the attack animation
		gameObject.GetComponent<Animation> ().CrossFade (enemyAttackAnimations [0], .2f);
		gameObject.GetComponent<Animation> ().PlayQueued (enemyAttackAnimations[1]);
		gameObject.GetComponent<Animation> ().PlayQueued (enemyAttackAnimations [2]);
		//print ("You have hit the player, he currently has " + ph.currHealth + " health");

		hasHit = true;


		yield return new WaitForSeconds (timeToAttack);

		hasHit = false;

		if(!playerInRange && hasHit == false)
		{
			FindEnemyScript.enabled = true;
		}
		else
		{
			transform.LookAt (target);
			StartCoroutine(Attack(Player));
		}
	}

	void Update ()
	{
		if (Vector3.Distance(target.position, transform.position) <= attackRange) {
			print ("player in range");

			playerInRange = true;

			StartCoroutine(Attack(Player));
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
		if(gameObject.GetComponent <Animation>().IsPlaying (enemyAttackAnimations[1]))
		{

			enemyWeapon.GetComponent<Collider>().enabled = true;
		}
		else
		{
			enemyWeapon.GetComponent<Collider>().enabled = false;
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