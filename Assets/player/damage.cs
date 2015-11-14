using UnityEngine;
using System.Collections;

public class damage : MonoBehaviour {
	
	string damageType;
	
	//decides when to turn on and off collider
	bool colliderOff;
	//damage value that spins through the distance between the 2 numbers in the damageRange array
	int playerDamage;
	//gives a range from a min damage to a max damage of what damage can be dealt.
	public int[] damageRange;
	//critical hit chance. this spins through 0-100 and randomly chooses a number when it collides
	int crit;
	//if it picks a number equal to or less than the critChance, then it crits and deals bonus damage
	public int critChance;
	//damageNum is equal to the damage when they collide + arcaneDamageBonus + shadowDamageBonus
	public int damageNum;

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
	
	GameObject enemy;

	public GameObject damageText;

	public GameObject trail;


	
	void Update () {
		if(GetComponent<Collider>().enabled == true)
		{
			trail.SetActive(true);

		}
		if(GetComponent<Collider>().enabled == false)

			trail.SetActive(false);
		
	}
	
	void OnTriggerEnter(Collider hit){
		if(hit.gameObject.tag == ("enemyHitDetect"))
		{

			crit = Random.Range(1,100);
			playerDamage = Random.Range(damageRange[0],damageRange[1]);
			enemy = hit.gameObject;
			critical();

			bonusDamageTypeFormula();
			damageNum = (int)(playerDamage + arcaneDamageBonus + shadowDamageBonus + pierceDamageBonus);
			hit.GetComponent<enemyHealth>().currHealth -= damageNum;


			damageNumberPopUp();
			{
				print("base damage is " + playerDamage + ". A bonus damage is " + arcaneDamageBonus + ". S bonus damage is " + shadowDamageBonus + ". P bonus damage is " + pierceDamageBonus);
			}
		}
	}

	void damageNumberPopUp()
	{
		damageText.GetComponent<TextMesh>().text = damageNum.ToString();
		Instantiate (damageText, new Vector3(enemy.transform.position.x, enemy.transform.position.y +4.5f,enemy.transform.position.z), Quaternion.identity);

	}
	
	void critical(){
		if(crit <= critChance)
		{
			
			playerDamage = (int)(damageRange[1] * 1.5f);
			print("critical hit");
		}
		if(critChance < crit)
		{
			
			print("normal hit");
		}
	}
	
	void bonusDamageTypeFormula(){
		arcaneDamageBonus = (int)((arcaneDamageMult * playerDamage)/enemy.GetComponent<enemyHealth>().adResistValue);
		shadowDamageBonus = (int)((shadowDamageMult * playerDamage)/enemy.GetComponent<enemyHealth>().sdResistValue);
		pierceDamageBonus = (int)((pierceDamageMult * playerDamage)/enemy.GetComponent<enemyHealth>().pdResistValue);
		
		
		
	}
}
	/*
	void textColour()
	{
		damageText.

	}
}

	
*/
	
