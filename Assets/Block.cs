﻿using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour 
	
{
	
	bool isBlocking;
	
	public float damageReduction;
	
	public int damageBlocked;
	
	public int damageBlockedTotal;
	
	GameObject enemyWeapon;
	
	GameObject player;
	
	GameObject shieldIcon;
	
	public float orbitSpeed;
	
	// Use this for initialization
	void Start () 
	{
		//player = GameObject.FindGameObjectWithTag ("Player");
		GetComponent<MasterPlayerStateScript> ().canBlock = true;
		shieldIcon = GameObject.FindGameObjectWithTag ("Icon_Shield");
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown("space"))
		{
			if(GetComponent<MasterPlayerStateScript>().canBlock == true)
			{
				if(GetComponent<MasterPlayerStateScript>().isAttacking == false && GetComponent<MasterPlayerStateScript>().isDashing == false)
				{
					
					GetComponent<MasterPlayerStateScript>().isBlocking = true;
				}
			}
		}
		else if(Input.GetKeyUp ("space"))
		{
			GetComponent<MasterPlayerStateScript>().isBlocking = false;
			
		}
		if(GetComponent<MasterPlayerStateScript>().isBlocking == true)
		{
			shieldIcon.gameObject.SetActive(true);
			shieldIcon.transform.Rotate(Vector3.up, Time.deltaTime * orbitSpeed);
			Debug.Log ("you are blocking now");	
			
			
		}
		if(GetComponent<MasterPlayerStateScript>().isBlocking == false)
		{
			shieldIcon.gameObject.SetActive(false);
			Debug.Log ("you are not blocking");
			
		}
		
	}
	
	void OnTriggerEnter(Collider hit)
	{
		if(hit.CompareTag ("enemyWeapon"))
		{
			if(GetComponent<MasterPlayerStateScript>().isBlocking == true)
			{
				damageBlocked = damageBlocked + GetComponent<playerHealth>().damageTaken;
				
			}
		}
	}
	
}

