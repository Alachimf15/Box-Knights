using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {

 	public GameObject enemy;
	//static var accessible by the damage script
	public int[] potentialHealth;
	int maxHealth;
	//able to assign health in the inspector to specialize different enemy healths without multiple scripts
	public int currHealth;
	//resistance to arcane damage. The higher the number, the less bonus arcane damage this object takes and vice versa. CAN NEVER EQUAL 0!!
 	float arcaneDamageResist;
	//resistance to shadow damage. The higher the number, the less bonus shadow damage this object takes and vice versa. CAN NEVER EQUAL 0!!
	float shadowDamageResist;
	//resistance to shadow damage. The higher the number, the less bonus shadow damage this object takes and vice versa. CAN NEVER EQUAL 0!!
	float pierceDamageResist;
	//able to assign arcane damage resist variable in the inspector to lessen hardcoding
	public float adResistValue;
	//able to assign shadow damage resist variable in the inspector to lessen hardcoding
	public float sdResistValue;
	//able to assign shadow damage resist variable in the inspector to lessen hardcoding
	public float pdResistValue;

	public GameObject blocker;


	void Update()
	{
		die();
		arcaneDamageResist = adResistValue;
		shadowDamageResist = sdResistValue;
		pierceDamageResist = pdResistValue;
		
	}
	
	void Awake()
	{

	}
	
	void Start () 
	{
		maxHealth = Random.Range(potentialHealth[0], potentialHealth[1]);
		currHealth = maxHealth;

		print("this enemy has " + currHealth + " health");
	}
	
	
	
	void die()
	{
		if(currHealth <= 0)
		{
			if (blocker != null) {
				blocker.GetComponent<blockers> ().enemies.Remove (enemy);
				
			}
			//removes the object if it's health is equalto or less than 0
			Destroy(this.transform.parent.gameObject);
			
		}
	}
}