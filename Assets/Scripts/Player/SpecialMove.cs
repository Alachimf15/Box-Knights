using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//AOE Damage Script by Dayniel DeGuzman
//11/17/2015

public class SpecialMove : MonoBehaviour {

	//how big the aoe is
	public float radius;
	//location. Can be anything really in case you know there are bombs or whatever
//	Vector3 location;
	//baseDamage
	public float damage;
	//final damage after calculation
	float damageNum;
	//a list of all the gameobjects hit by the AOE
	private List <Collider> enemyList = new List<Collider>();
	
	//multiplies the damage by a certain number. 0 for no bonus damage of this type
	public float arcaneDamageMult;
	//multiplies the damage by a certain number. 0 for no bonus damage of this type
	public float shadowDamageMult;
	//multiplies the damage by a certain number. 0 for no bonus damage of this type
	public float pierceDamageMult;
	//formula to calculate bonus damage if it deals bonus arcane damage
	float arcaneDamageBonus;
	//formula to calculate bonus shadow damage if the attack deals bonus shadow damage
	float shadowDamageBonus;
	//formula to calculate bonus shadow damage if the attack deals bonus pierce damage
	float pierceDamageBonus;




	
	// Update is called once per frame
	void Update () 
	{

		//checks if you have the special and if you are in a state to perform it ie if you aren't attacking, etc.
		if(GetComponent<MasterPlayerStateScript>().canPerformSpecial == true && GetComponent<MasterPlayerStateScript>().specialAvailable == true)
		{
		if(Input.GetKeyDown(KeyCode.F))
			{
				AreaDamageEnemies(gameObject.transform.position, radius, damage);
				GetComponent<MasterPlayerStateScript>().specialCasted = true;
			}
		}
	}

	void AreaDamageEnemies(Vector3 location, float radius, float damage)
	{
		//checks aoe
		enemyList = new List <Collider>(Physics.OverlapSphere (location, radius));
		//sets location
		location =  gameObject.transform.position;
		print (location);

		//for every enemy hit by the aoe that was added to the list...
		for(int i = 0; i < enemyList.Count; i++)
		{
			print (enemyList.Count);
			
			//if the enemy collided is tagged with hitdetect
			if(enemyList[i].CompareTag("enemyHitDetect"))
			{
				//apply damage to enemies hit by the aoe, calculating bonuses and shit
				arcaneDamageBonus = (int)((arcaneDamageMult * damage)/enemyList[i].GetComponent<enemyHealth>().adResistValue);
				shadowDamageBonus = (int)((shadowDamageMult * damage)/enemyList[i].GetComponent<enemyHealth>().sdResistValue);
				pierceDamageBonus = (int)((pierceDamageMult * damage)/enemyList[i].GetComponent<enemyHealth>().pdResistValue);

				//doin it's thang calculating the final damage
				damageNum = (int)(damage + arcaneDamageBonus + shadowDamageBonus + pierceDamageBonus);

				//damages enemies
				enemyList[i].GetComponent<enemyHealth>().currHealth -= (int)damageNum;

				print ("Your special did " + damageNum);
		
			}

		}

	}
}
