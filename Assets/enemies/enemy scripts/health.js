#pragma strict

var enemy : GameObject;
//static var accessable by the damage script
var maxHealth : int[];
//able to assign health in the inspector to specialize different enemy healths without multiple scripts
var currHealth : int;
//resistance to arcane damage. The higher the number, the less bonus arcane damage this object takes and vice versa. CAN NEVER EQUAL 0!!
private var arcaneDamageResist : float;
//resistance to shadow damage. The higher the number, the less bonus shadow damage this object takes and vice versa. CAN NEVER EQUAL 0!!
private var shadowDamageResist : float;
//resistance to shadow damage. The higher the number, the less bonus shadow damage this object takes and vice versa. CAN NEVER EQUAL 0!!
private var pierceDamageResist : float;
//able to assign arcane damage resist variable in the inspector to lessen hardcoding
var adResistValue : float;
//able to assign shadow damage resist variable in the inspector to lessen hardcoding
var sdResistValue : float;
//able to assign shadow damage resist variable in the inspector to lessen hardcoding
var pdResistValue : float;

function Update()
{
	die();
	arcaneDamageResist = adResistValue;
	shadowDamageResist = sdResistValue;
	pierceDamageResist = pdResistValue;

}

function Awake()
{
	enemy = GameObject.FindGameObjectWithTag("enemy");
}

function Start () 
{
	currHealth = Random.Range(maxHealth[0], maxHealth[1]);

	print("this enemy has " + currHealth + " health");
}



function die()
{
	if(currHealth <= 0)
	{
		//removes the object if it's health is equalto or less than 0
		Destroy(this.transform.parent.gameObject);

	}
}