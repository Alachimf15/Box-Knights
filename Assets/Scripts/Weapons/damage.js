#pragma strict

var damageType : String;

//decides when to turn on and off collider
var colliderOff : boolean;
//damage value that spins through the distance between the 2 numbers in the damageRange array
private var damage : int;
//gives a range from a min damage to a max damage of what damage can be dealt.
var damageRange : int[];
//critical hit chance. this spins through 0-100 and randomly chooses a number when it collides
private var crit : int;
//if it picks a number equal to or less than the critChance, then it crits and deals bonus damage
var critChance : int;
//damageNum is equal to the damage when they collide + arcaneDamageBonus + shadowDamageBonus
var damageNum : int;
//multiplies the damage by a certain number. 0 for no bonus damage of this type
var arcaneDamageMult : float;
//multiplies the damage by a certain number. 0 for no bonus damage of this type
var shadowDamageMult : float;
//multiplies the damage by a certain number. 0 for no bonus damage of this type
var pierceDamageMult : float;
//formula to calculate bonus damage if it deals bonus arcane damage
private var arcaneDamageBonus : int;
//formula to calculate bonus shadow damage if the attack deals bonus shadow damage
private var shadowDamageBonus : int;
//formula to calculate bonus shadow damage if the attack deals bonus pierce damage
private var pierceDamageBonus : int;

private var enemy : GameObject;

var passiveApply : boolean;


function Start () {

}

function Awake(){


}

function Update () {

crit = Random.Range(1,100);

}

function OnTriggerEnter(hit : Collider){
if(hit.GetComponent.<Collider>().CompareTag("enemy"))
{


damage = Random.Range(damageRange[0],damageRange[1]);
enemy = hit.gameObject;
passiveApply = true;
critical();
bonusDamageTypeFormula();
damageNum = damage + arcaneDamageBonus + shadowDamageBonus + pierceDamageBonus;
hit.GetComponent(health).currHealth -= damageNum;
print("base damage is " + damage + ". A bonus damage is " + arcaneDamageBonus + ". S bonus damage is " + shadowDamageBonus + ". P bonus damage is " + pierceDamageBonus);


}
}



function critical(){
if(crit <= critChance)
{

damage = (damageRange[1] * 1.5);
print("critical hit");
}
if(critChance < crit)
{

print("normal hit");
}
}

function bonusDamageTypeFormula(){
arcaneDamageBonus = ((arcaneDamageMult * damage)/enemy.GetComponent(health).adResistValue);
shadowDamageBonus = ((shadowDamageMult * damage)/enemy.GetComponent(health).sdResistValue);
pierceDamageBonus = ((pierceDamageMult * damage)/enemy.GetComponent(health).pdResistValue);



}


//function damageColor(){
//if(damageType == "arcane")
//{
//gui.guiText.material.color = Color(0,.6,3,1);
//}
//if(damageType == "shadow")
//{
//gui.guiText.material.color = Color(.7,0,.7,1);
//}
//if(damageType == "pierce")
//{
//gui.guiText.material.color = Color(2.31,2.34,0,1);
//}
//if(damageType == "normal")
//{
//gui.guiText.material.color = Color(2.55,0,0,1);
//}
//}
 
 
