using UnityEngine;
using System.Collections;

//this is a script showing what state the player is in to work out inter-mechanic interactions



public class MasterPlayerStateScript : MonoBehaviour 
{
	public bool canAttack;
	public bool isAttacking;
	
	public bool canDash;
	public bool isDashing;

	public bool dashCancelReset;

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

		if(isAttacking == true)
		{
			isIdle = false;
		}
		if((isDashing == true)&&(dashCancelReset == false))
			{
		
			canAttack = false;
			isIdle = false;
			canBlock = false;
			}
		if((isDashing == true)&&(isAttacking == true))
		{
			canAttack = true;
			isIdle = false;
			canBlock = false;

		}
		if(isBlocking == true)
		{
			canAttack = false;
			isIdle = false;
			canDash = false;
		}
		if((isAttacking == false)&&(isBlocking == false)&&(isDashing == false))
		{
			isIdle = true;

	}
		if(isIdle == true)
		{
			canAttack = true;
			isIdle = true;
			canBlock = true;
		}
	}
}