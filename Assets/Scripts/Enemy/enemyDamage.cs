using UnityEngine;
using System.Collections;

public class enemyDamage : MonoBehaviour {
	
	string damageType;
	
	//decides when to turn on and off collider
	bool colliderOff;
	//damage value that spins through the distance between the 2 numbers in the damageRange array
	int enemyNormDamage;
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
	public GameObject enemy;
	
	public bool hitPlayer;
	
	GameObject player;
	
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
		
	}
	
	
	
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider hit){
		if(hit.gameObject.tag == ("Player"))
		{
			hitPlayer = true;
			player = hit.gameObject;
			crit = Random.Range(1,100);
			//picks a random value from a range to determine how much damage to do to the player.
			enemyNormDamage = Random.Range(damageRange[0],damageRange[1]);
			//determines if you critically strike the target or not;
			critical();
			bonusDamageTypeFormula();
			
			damageNum = (int)(enemyNormDamage + arcaneDamageBonus + shadowDamageBonus + pierceDamageBonus);
			
			
			
		}
	}
	
	
	
	void critical(){
		if(crit <= critChance)
		{
			
			//enemyNormDamage = ((damageRange[1]) * 1.5));
			print("critical hit");
		}
		if(critChance < crit)
		{
			
			print("normal hit");
		}
	}
	
	void bonusDamageTypeFormula(){
		arcaneDamageBonus = ((arcaneDamageMult * enemyNormDamage)/player.GetComponent<playerHealth>().adResistValue);
		shadowDamageBonus = ((shadowDamageMult * enemyNormDamage)/player.GetComponent<playerHealth>().sdResistValue);
		pierceDamageBonus = ((pierceDamageMult * enemyNormDamage)/player.GetComponent<playerHealth>().pdResistValue);
		
		
		
	}
}
