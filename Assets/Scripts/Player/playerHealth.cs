using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour {
	

	public int currHealth;
	//able to assign health in the inspector to specialize different enemy healths without multiple scripts
	public int maxHealth;

	public int damageTaken;
	//resistance to arcane damage. The higher the number, the less bonus arcane damage this object takes and vice versa. CAN NEVER EQUAL 0!!
	float playerArcaneDamageResist;
	//resistance to shadow damage. The higher the number, the less bonus shadow damage this object takes and vice versa. CAN NEVER EQUAL 0!!
	float playerShadowDamageResist;
	//resistance to shadow damage. The higher the number, the less bonus shadow damage this object takes and vice versa. CAN NEVER EQUAL 0!!
	float playerPierceDamageResist;
	//able to assign arcane damage resist variable in the inspector to lessen hardcoding
	public float adResistValue;
	//able to assign shadow damage resist variable in the inspector to lessen hardcoding
	public  float sdResistValue;
	//able to assign shadow damage resist variable in the inspector to lessen hardcoding
	public float pdResistValue;

	
	void Awake()
	{
		currHealth = maxHealth;
	}
	
	void Update()
	{
		
		die();
		playerArcaneDamageResist = adResistValue;
		playerShadowDamageResist = sdResistValue;
		playerPierceDamageResist = pdResistValue;
		//print("player health is " + currHealth);
		
		if(currHealth > maxHealth)
		{
			currHealth = maxHealth;
		}
	}

	//this is where it detects if the player has taken damage, it will first run through to see if you are blocking, and if so,
	//reduce the damage, if not, then you take full damage. Unless I want to add some other crap here like a passive buff or something idk

	void OnTriggerEnter(Collider enemy)
	{
		if (enemy.CompareTag ("enemyWeapon"))
		{
			if(GetComponent<MasterPlayerStateScript>().isBlocking == false)
			{
			damageTaken = enemy.GetComponent<enemyDamage>().damageNum;

			}
			if(GetComponent<MasterPlayerStateScript>().isBlocking == true)
			{
				damageTaken = (int)(enemy.GetComponent<enemyDamage>().damageNum * GetComponent<Block>().damageReduction);

			}
		
		currHealth -= damageTaken;
			Debug.Log ("you have been hit by an enemy, you have taken " + damageTaken + " damage");

		}

	}
	
	
	
	
	void die()
	{
		if(currHealth <= 0)
		{
			//removes the object if it's health is equalto or less than 0
			Application.LoadLevel (4);
		}
	}
}
