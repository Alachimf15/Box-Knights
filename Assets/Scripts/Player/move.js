/// This script moves the character controller forward 
/// and sideways based on the arrow keys.
/// It also jumps when pressing space.
/// Make sure to attach a character controller to the same game object.
/// It is recommended that you make only one call to Move or SimpleMove per frame.	
var speed : float;
static var movement : boolean;
var gravity : float = 999999999.0;
private var floor : GameObject;
private var moveDirection : Vector3 = Vector3.zero;
private var moveRotation  : Vector3 = Vector3.zero;
var startingSpeed : float;
var speedIncrease : float;
var maxSpeed : float;
var stamina : Stamina;
var controller : CharacterController;
var hit : RaycastHit;
private var raycastLocation : GameObject;



function Start()
{
	controller = GetComponent(CharacterController);
	stamina = GetComponent(Stamina);
	raycastLocation = GameObject.Find("floorLocator");
}

function Update() 
{
var down = transform.TransformDirection (Vector3.down);

if(Physics.Raycast(raycastLocation.transform.position, down, hit, 100))
{
	if(hit.collider.CompareTag("Floor"))
	{

	moveControl();
	moved();	

		// We are grounded, so recalculate
		// move direction directly from axes
		moveDirection = Vector3(Input.GetAxis("Vertical"), hit.point.y - gameObject.transform.position.y,
		                        (Input.GetAxis("Horizontal") * -1));
		moveRotation = Vector3(0,180,0);
		             
		moveDirection = transform.TransformDirection(moveDirection);
		
		moveDirection *= speed;
	
	
	

	// Apply gravity
	moveDirection.y -= gravity * 10;
	
	// Move the controller
	controller.Move(moveDirection * Time.deltaTime);
	}
	}
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
	if(movement == true)
	{
	if(speed < maxSpeed)
	{

	speed += speedIncrease;

	}
	if(speed >= maxSpeed)
	{
	speed = maxSpeed;

	}
	}
	


}