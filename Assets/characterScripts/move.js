﻿/// This script moves the character controller forward 
/// and sideways based on the arrow keys.
/// It also jumps when pressing space.
/// Make sure to attach a character controller to the same game object.
/// It is recommended that you make only one call to Move or SimpleMove per frame.	
private var speed : float;
static var movement : boolean;
var gravity : float = 20.0;
private var moveDirection : Vector3 = Vector3.zero;
private var moveRotation  : Vector3 = Vector3.zero;
var startingSpeed : float;
var speedIncrease : float;
var maxSpeed : float;
var stamina : Stamina;
var controller : CharacterController;

function Start()
{
	controller = GetComponent(CharacterController);
	stamina = GetComponent(Stamina);
}

function Update() 
{
	moveControl();
	moved();	
	
	if (controller.isGrounded) 
	{
		// We are grounded, so recalculate
		// move direction directly from axes
		moveDirection = Vector3(Input.GetAxis("Vertical"), 0,
		                        (Input.GetAxis("Horizontal") * -1));
		moveRotation = Vector3(0,180,0);
		             
		moveDirection = transform.TransformDirection(moveDirection);
		
		moveDirection *= speed;
	}
	

	// Apply gravity
	moveDirection.y -= gravity * Time.deltaTime;
	
	// Move the controller
	controller.Move(moveDirection * Time.deltaTime);
}

function moveControl()
{
	if((Input.GetAxis("Vertical"))||(Input.GetAxis("Horizontal")))
	{
		movement = !false;
		print("we are moving");
	}
	else
	{	
		movement = !true;
	}
}
function moved()
{

	if(movement == false)
	{
		speed = startingSpeed;

	}

	if(speed < maxSpeed)
	{

	speed += speedIncrease;

	}
	if(speed >= maxSpeed)
	{
	speed = maxSpeed;

	}



}