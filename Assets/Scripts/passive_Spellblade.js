#pragma strict

//every hit on an enemy causes runic energy to build within the blade, after a successful number of hits, the blade overflows with runic energy,
//causing your next attack to deal bonus arcane damage

//grabs the correct collider utilized for this script
private var weapon : GameObject;

//counts how many times you've hit the enemy
var attackCounter : int;
//required number of hits before the passive effect goes off, once your attacks = maxHits number, next attack will trigger the proceeding effect
var maxHits : int;


//arcane damage multiplier bonus for next attack
var arcaneBonus : float;


function Start () {
weapon = GameObject.FindGameObjectWithTag("weapon");
}

function OnTriggerEnter(weapon : Collider){
if(weapon.gameObject.GetComponent.<Collider>().CompareTag("enemy"))
{

attackCounter++;
}
if(attackCounter == maxHits)
{
print("passive On Hit is ready. Next attack will trigger");
spellBlade();

}

//if it's the next attack after the number of attack requirement has been met, fire off passive on next hit then reset the counter
if(attackCounter == maxHits + 1)
{
disablePassive();
attackCounter = 0;


}
}


function spellBlade(){

weapon.GetComponent(damage).arcaneDamageMult += arcaneBonus;
}

function disablePassive(){
weapon.GetComponent(damage).arcaneDamageMult -= arcaneBonus;


}

function Update () {

}