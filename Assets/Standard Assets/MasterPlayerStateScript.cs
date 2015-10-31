using UnityEngine;
using System.Collections;

//this is a script showing what state the player is in to work out inter-mechanic interactions



public class MasterPlayerStateScript : MonoBehaviour 
{
	public bool canAttack;
	public bool isAttacking;
	
	public bool canDash;
	public bool isDashing;

	public bool dashStop;

	public bool canRotate;

	public bool isIdle;


	public bool canBlock;
	public bool isBlocking;

	public bool canSwitchWeapons;

	
	void Start () 
	{
		canAttack = true;
		canDash = true;
	}
	

	void Update () 
	{
		if(isDashing == true)
			{
			canAttack = false;
			canBlock = false;
			}
		if(isBlocking == true)
		{
			canAttack = false;
			canDash = false;
		}
		if(isDashing == false && isAttacking == false)
		{
			canBlock = true;
		}

	}
}