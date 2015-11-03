#pragma strict

private var player : GameObject;
private var moveScript : move;
private var rotateScript : mouse;
private var playerStateScript : MasterPlayerStateScript;
//checks how many times the player has pressed the attack button
var clickCount : int;
//stores idle animations as strings for reference
var idleActions : String[];
//stores basic attack animations as strings for reference
var weaponComboHit : String[];
//stores basic attack recovery animations as strings for reference
var weaponComboRecover : String[];

//collider off start and collider off end creates a time "zone" in the animation for when the collider turns on and off. Collider off start is when the
//collider is off for the beginning of the animation, and collider off end is when the collider turns off towards the end of the animation
var colliderOffStart : float[];

var colliderOffEnd : float[];
//the time in the animation where you press the button for the next attack in the combo
var hitCollisionWindow : float[];
//gets the right collider to turn on and off
private var weapon : GameObject;

var dashCancelWindowStart : float[];

var dashCancelWindowEnd : float[];






function Awake(){
player = GameObject.FindGameObjectWithTag("Player");
moveScript = player.gameObject.GetComponent(move);

}


function Update(){
resetAttack();
idle();
//colliderHandler();
//swapStopAnims();

attackThreeDashCancel();
attackTwoDashCancel();
attackOneDashCancel();

mouseControl1();
mouseControl2();
mouseControl3();
hit3Collider();
hit3Anim();
hit2Collider();
hit2Anim();
hit1Collider();
hit1Anim();
dashCancel();



}

function Start(){
weapon = GameObject.FindGameObjectWithTag("weapon");
playerStateScript = player.gameObject.GetComponent(MasterPlayerStateScript);
print(weapon.name);
weapon.GetComponent.<Collider>().enabled = false;
}


 function idle(){
 //this is the code for idle. Will probably add flag for different states ie idle boolean flag, attacking boolean flag, dash boolean flag, etc.

if(playerStateScript.isIdle == true)
{
player.GetComponent(move).enabled = true;
GetComponent.<Animation>().CrossFadeQueued(idleActions[0], .4f);
 weapon.GetComponent.<Collider>().enabled = false;
GetComponent(mouse).enabled = true;
player.gameObject.GetComponent(swapWeapons).enabled = true;
playerStateScript.canDash = true;
playerStateScript.canAttack = true;
playerStateScript.isAttacking = false;
}
}

function dashCancel(){
if(playerStateScript.isDashing == true)
{




}
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 
 function resetAttack(){
 if(clickCount == 0)
 {
 	playerStateScript.isAttacking = false;
 }
 }
 
  function hit1Anim(){
  //states that if you left click while click Count(the variable for tracking which attack to fire off) is 0 meaning you're probably idle,
  //then clickCount adds 1 to signal firing off the first attack which disables movement, mouse control, and will probably play the attack
  //animation

  if(Input.GetMouseButtonDown(0)&&(clickCount == 0)&&(playerStateScript.canAttack == true))
  {
  //this will access the master player state script and change it to true if it was initially false

  
  clickCount = 1;
  player.GetComponent(move).enabled = false;
GetComponent(mouse).enabled = false;


  }
  if(clickCount == 1)
  {
  //plays first hit animation and disables weapon swapping
  GetComponent.<Animation>().Play(weaponComboHit[0]);
  GetComponent.<Animation>().CrossFadeQueued(weaponComboRecover[0]);
player.gameObject.GetComponent(swapWeapons).enabled = false;
	playerStateScript.isAttacking = true;
	playerStateScript.isIdle = false;
print(clickCount);
  }
  
  

if((GetComponent.<Animation>()[weaponComboHit[0]].normalizedTime >= .95)&&(clickCount == 1))
  {

  clickCount = 0;
  
  //playerStateScript.isIdle = true;
  print(clickCount);
  }
  }
 
  
  
  
  //this will handle the collider/damage interaction on the first hit and determine when during the first hit animation to turn the collider off or on
  
  function hit1Collider(){
  if((GetComponent.<Animation>().IsPlaying(weaponComboHit[0]))&&(clickCount == 1))
  {
  if((GetComponent.<Animation>()[weaponComboHit[0]].normalizedTime <= colliderOffStart[0])||(GetComponent.<Animation>()[weaponComboHit[0]].normalizedTime >= colliderOffEnd[0]))
  {
  weapon.GetComponent.<Collider>().enabled = false;
  }
  else
  {
   weapon.GetComponent.<Collider>().enabled = true;
  }
  }
  }
  
  function mouseControl1(){
//this function allows you to change directions in between attacks in the combo so you can hit an enemy in front of you with the first hit,
//then an enemy behind you with the second hit etc.
if((GetComponent.<Animation>().IsPlaying(weaponComboHit[0]))&&(GetComponent.<Animation>()[weaponComboHit[0]].normalizedTime <= .1))
{
GetComponent(mouse).enabled = true;

}
else if((GetComponent.<Animation>().IsPlaying(weaponComboHit[0]))&&(GetComponent.<Animation>()[weaponComboHit[0]].normalizedTime >= .1)){
GetComponent(mouse).enabled = false;

}
}

function attackOneDashCancel(){
if((GetComponent.<Animation>().IsPlaying(weaponComboHit[0]))&&(clickCount == 1))
{
if((GetComponent.<Animation>()[weaponComboHit[0]].normalizedTime <= dashCancelWindowStart[0])||(GetComponent.<Animation>()[weaponComboHit[0]].normalizedTime >= dashCancelWindowEnd[0]))
{ 
playerStateScript.canDash = false;

}

else if((GetComponent.<Animation>()[weaponComboHit[0]].normalizedTime >= dashCancelWindowStart[0])||(GetComponent.<Animation>()[weaponComboHit[0]].normalizedTime <= dashCancelWindowEnd[0]))

{
playerStateScript.canDash = true;


}
}
}



////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function hit2Anim(){
  if(playerStateScript.canAttack == true)
  {
if(GetComponent.<Animation>().IsPlaying(weaponComboHit[0]))
{
if((Input.GetMouseButtonDown(0))&&((hitCollisionWindow[0] <= GetComponent.<Animation>()[weaponComboHit[0]].normalizedTime)))
{
clickCount = 2;
player.GetComponent(move).enabled = false;
GetComponent(mouse).enabled = true;
}
if(clickCount == 2)
{
  GetComponent.<Animation>().Play(weaponComboHit[1]);
  GetComponent.<Animation>().CrossFadeQueued(weaponComboRecover[1]);
player.gameObject.GetComponent(swapWeapons).enabled = false;
	playerStateScript.isAttacking = true;
	playerStateScript.isIdle = false;
print(clickCount);
}
}
if((GetComponent.<Animation>()[weaponComboHit[1]].normalizedTime >= .95)&&(clickCount == 2))
{

clickCount = 0;
  //playerStateScript.isIdle = true;
print(clickCount);
}
}
}

  function hit2Collider(){
  //handles the collider on the weapon to turn on once the attack starts. The collider will be on for a certain timeframe of the attack
  //animation collider off start var says when during the animation should the collider turn on, and the collider off end says when it should turn off
  if(GetComponent.<Animation>().IsPlaying(weaponComboHit[1]))
  {
  if((GetComponent.<Animation>()[weaponComboHit[1]].normalizedTime <= colliderOffStart[1])||(GetComponent.<Animation>()[weaponComboHit[1]].normalizedTime >= colliderOffEnd[1]))
  {
   weapon.GetComponent.<Collider>().enabled = false;
  }
  else
  {
   weapon.GetComponent.<Collider>().enabled = true;
  }
  }
  }

  function mouseControl2(){
//this function allows you to change directions in between attacks in the combo so you can hit an enemy in front of you with the first hit,
//then an enemy behind you with the second hit etc.
if((GetComponent.<Animation>().IsPlaying(weaponComboHit[1]))&&(GetComponent.<Animation>()[weaponComboHit[1]].normalizedTime <= .1))
{
GetComponent(mouse).enabled = true;

}
else if((GetComponent.<Animation>().IsPlaying(weaponComboHit[1]))&&(GetComponent.<Animation>()[weaponComboHit[1]].normalizedTime >= .1)){
GetComponent(mouse).enabled = false;

}
}

function attackTwoDashCancel(){
if((playerStateScript.isAttacking == true)&&(clickCount == 2))
{
if((GetComponent.<Animation>()[weaponComboHit[1]].normalizedTime <= dashCancelWindowStart[1])||(GetComponent.<Animation>()[weaponComboHit[1]].normalizedTime >= dashCancelWindowEnd[1]))
{ 
playerStateScript.canDash = false;

}

else if((GetComponent.<Animation>()[weaponComboHit[1]].normalizedTime >= dashCancelWindowStart[1])||(GetComponent.<Animation>()[weaponComboHit[0]].normalizedTime <= dashCancelWindowEnd[1]))

{
playerStateScript.canDash = true;



}
}
}


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function hit3Anim(){
//same as the other hits, will play animation and stuff
  if(playerStateScript.canAttack == true)
  {
if(GetComponent.<Animation>().IsPlaying(weaponComboHit[1]))
{
if((Input.GetMouseButtonDown(0))&&((hitCollisionWindow[1] <= GetComponent.<Animation>()[weaponComboHit[1]].normalizedTime)))
{
clickCount = 3;
player.GetComponent(move).enabled = false;

}
if(clickCount == 3)
{
  GetComponent.<Animation>().Play(weaponComboHit[2]);
  GetComponent.<Animation>().CrossFadeQueued(weaponComboRecover[2]);
player.gameObject.GetComponent(swapWeapons).enabled = false;
	playerStateScript.isAttacking = true;
	playerStateScript.isIdle = false;
print(clickCount);
}
}
if(GetComponent.<Animation>()[weaponComboHit[2]].normalizedTime >= .9)
{

clickCount = 0;
print(clickCount);

}
}
}


  function hit3Collider(){
  if((GetComponent.<Animation>().IsPlaying(weaponComboHit[2]))&&(clickCount == 3))
  {
  if((GetComponent.<Animation>()[weaponComboHit[2]].normalizedTime <= colliderOffStart[2])||(GetComponent.<Animation>()[weaponComboHit[2]].normalizedTime >= colliderOffEnd[2]))
  {
  weapon.GetComponent.<Collider>().enabled = false;
  }
  else
  {
  //weapon.GetComponent(damage).colliderOff = false;
   weapon.GetComponent.<Collider>().enabled = true;
  }
  }
  }
  
    function mouseControl3(){
//this function allows you to change directions in between attacks in the combo so you can hit an enemy in front of you with the first hit,
//then an enemy behind you with the second hit etc.
if((GetComponent.<Animation>().IsPlaying(weaponComboHit[2]))&&(GetComponent.<Animation>()[weaponComboHit[2]].normalizedTime <= .1))
{
GetComponent(mouse).enabled = true;

}
else if((GetComponent.<Animation>().IsPlaying(weaponComboHit[2]))&&(GetComponent.<Animation>()[weaponComboHit[2]].normalizedTime >= .1)){
GetComponent(mouse).enabled = false;

}
}

function attackThreeDashCancel(){
if((playerStateScript.isAttacking == true)&&(clickCount == 3))
{
if((GetComponent.<Animation>()[weaponComboHit[2]].normalizedTime <= dashCancelWindowStart[2])||(GetComponent.<Animation>()[weaponComboHit[2]].normalizedTime >= dashCancelWindowEnd[2]))
{ 
playerStateScript.canDash = false;

}

else if((GetComponent.<Animation>()[weaponComboHit[2]].normalizedTime >= dashCancelWindowStart[2])||(GetComponent.<Animation>()[weaponComboHit[2]].normalizedTime <= dashCancelWindowEnd[2]))

{
playerStateScript.canDash = true;


}
}
}


