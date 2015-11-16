using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour 
{
	int layerFloor;
	LayerMask floorLayer;
	public float speed;
	public bool movement;
	public float gravity;
	GameObject floor;
	Vector3 moveDirection = Vector3.zero;
	Vector3 moveRotation = Vector3.zero;
	public float startingSpeed;
	public float speedIncrease;
	public float maxSpeed;
	Stamina stamina;
	CharacterController controller;
	RaycastHit hit;
	GameObject raycastLocation;

	public float blockSpeedReduce;
	
	// Use this for initialization
	void Start () 
	{
		//anything tagged floor will be on the floor layer. This selects that layer
		floorLayer = (1 << LayerMask.NameToLayer("Floor"));
	
		controller = gameObject.GetComponent<CharacterController>();
		stamina = GetComponent<Stamina>();
		raycastLocation = GameObject.Find("floorLocator");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//shoots a ray down from above the player's head
		Vector3 down = raycastLocation.transform.TransformDirection (Vector3.down);

		//shoots a layer downward on the floorLayer
		if(Physics.Raycast(raycastLocation.transform.position, down, out hit, 100, floorLayer))
		{

				if(hit.collider.CompareTag("Floor"))
				{
					
					moveControl();
					moved();	
					
					// We are grounded, so recalculate
					// move direction directly from axes
				//finds direction to move, player's y value always set to be the floor
					moveDirection = new Vector3(Input.GetAxis("Vertical"), hit.point.y - gameObject.transform.position.y,
					                            (Input.GetAxis("Horizontal") * -1));
					moveRotation = new Vector3(0,180,0);
					

					moveDirection = gameObject.transform.TransformDirection(moveDirection);
					
					moveDirection *= speed;
					
					
					
					
					// Apply gravity
					moveDirection.y -= gravity * 10;
					
					// Move the controller
					controller.Move(moveDirection * Time.deltaTime);
				}
			}

	}
	void moveControl()
	{
		if((Input.GetAxis("Vertical") != 0)||(Input.GetAxis ("Horizontal") != 0))
		{
			movement = !false;
			print("we are moving");
		}
		else
		{	
			movement = !true;
		}
	}
	void moved()
	{
	if(GetComponent<MasterPlayerStateScript>().isAttacking == true)
		{
			speed = 0;
	

		}


		if(movement == false)
		{
			speed = startingSpeed;
		}
		else if(movement == true)
		{
			if(GetComponent<MasterPlayerStateScript>().isBlocking == true)
			{
				speed = maxSpeed * blockSpeedReduce - speedIncrease;
				
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
	}
}
