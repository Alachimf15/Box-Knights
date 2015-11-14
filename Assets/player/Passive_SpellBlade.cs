using UnityEngine;
using System.Collections;

public class Passive_SpellBlade : MonoBehaviour {
	//every hit on an enemy causes runic energy to build within the blade, after a successful number of hits, the blade overflows with runic energy,
	//causing your next attack to deal bonus arcane damage

	
	//counts how many times you've hit the enemy
	public int attackCounter;
	//required number of hits before the passive effect goes off, once your attacks = maxHits number, next attack will trigger the proceeding effect
	public int maxHits;

	
	
	//arcane damage multiplier bonus for next attack
	public float arcaneBonus;
	
	bool attackTrigger;



	void OnTriggerEnter(Collider weapon){
		if(weapon.gameObject.tag == "enemyHitDetect")
		{
			attackCounter++;
		}
		if(attackCounter == maxHits && attackTrigger == false)
		{

			print("passive On Hit is ready. Next attack will trigger");
			spellBlade();
			attackTrigger = true;

			
		}
		
		//if it's the next attack after the number of attack requirement has been met, fire off passive on next hit then reset the counter
		if(attackTrigger == true && attackCounter == maxHits + 1)
		{
			disablePassive();
			attackCounter = 0;
			print ("reset");
			attackTrigger = false;
			}
		}
			
	
	void spellBlade(){
		gameObject.GetComponent<damage>().arcaneDamageMult += arcaneBonus;
	
	}
	void disablePassive(){
		gameObject.GetComponent<damage>().arcaneDamageMult -= arcaneBonus;
		
		
	}
}
