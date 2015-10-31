using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour 

{
	//checks if you are blocking or not
	bool isBlocking;


	//multiplier for how much damage reduced you'll take. Keep it under 1 or else you'd take more damage. The lower the number, the less damage you'll take
	public float damageReduction;

	//how much damage you absorbed while blocking
	public int damageBlocked;

	public int damageBlockedTotal;

	//finds enemy weapon
	GameObject enemyWeapon;

	GameObject player;

	// Use this for initialization
	void Start () 
	{
		//player = GameObject.FindGameObjectWithTag ("Player");
		GetComponent<MasterPlayerStateScript> ().canBlock = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("space"))
		{

		//check if you currently aren't doing anything at the same time as you're trying to block ie you cant block while you are attacking or dashing
		if(GetComponent<MasterPlayerStateScript>().isAttacking == false && GetComponent<MasterPlayerStateScript>().isDashing == false)
		{
			//checks if you can block
			if(GetComponent<MasterPlayerStateScript>().canBlock == true)
			{

						//says that you are blocking
						GetComponent<MasterPlayerStateScript>().isBlocking = true;
				}
			}
		}
			else if(Input.GetKeyUp ("space"))
			{
				//says you aren't blocking
				GetComponent<MasterPlayerStateScript>().isBlocking = false;
				
			}
		if(GetComponent<MasterPlayerStateScript>().isBlocking == true)
		{

			Debug.Log ("you are blocking now");	
					
		}
		if(GetComponent<MasterPlayerStateScript>().isBlocking == false)
		{
			Debug.Log ("you are not blocking");

		}

	}

	void OnTriggerEnter(Collider hit)
	{
		if(hit.CompareTag ("enemyWeapon"))
		{
			if(GetComponent<MasterPlayerStateScript>().isBlocking == true)
			{
				//adds blocked damage to a variable which will check if you blocked enough damage to perform a special move
				damageBlocked = damageBlocked + GetComponent<playerHealth>().damageTaken;

			}
		}
	}

}
			
