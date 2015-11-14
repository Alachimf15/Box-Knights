using UnityEngine;
using System.Collections;

public class DashingScript : MonoBehaviour
{
	private bool wasMouseDown = false;
	
	public float dashDistance;
	
	public float dashSpeed;
	
	public Vector3 currPosition;
	
	public Vector3 playerPosition;
	
	//CharacterController playerCollider;
	
	GameObject dashDetector;
	
	GameObject floor;
	
	bool dashStop;
	
	MasterPlayerStateScript playerState;
	
	Stamina stamina;
	
	void Start()
	{
		dashDetector = GameObject.FindGameObjectWithTag ("weaponPrefab");
		playerState = GetComponent <MasterPlayerStateScript>();
		stamina = GetComponent<Stamina> ();
		floor = GameObject.FindGameObjectWithTag ("Floor");
		//playerCollider = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	//this update function is saying if the left mouse click is pressed and wasMouseDown = false; print that it was clicked. Then if wasMouseDown = true and the left mouse button
	//was released, then wasMouseDown is false and prints thyat the mouse was released. It basically is like an analogue switch detecting that the mouse was pressed then released
	void Update ()
	{
		playerPosition = transform.position;
		currPosition = gameObject.transform.position;
		if (Input.GetMouseButtonDown (1) && !wasMouseDown && stamina.Running && playerState.canDash == true && playerState.isDashing == false) 
		{
			// Do stuff
			Debug.Log ("Right mouse click!");
			
			//use ray cast that intersects with the floor plane. The position that the mouse is on the floor plane is returned as a vector 3 location. So if you point the mouse at a 
			//specific location, someVector will be a vector3 of where the mouse is on the plane
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			//RaycastHit hit;
			
			
			
			//if(Physics.Raycast (target.transform.position, Vector3.up, hit, 500))
			//{
			
			
			//}
			
			float distance = 1000f;
			if (Physics.Raycast (ray, distance)) 
			{
				Plane rayHit = new Plane(Vector3.up, gameObject.transform.localPosition);
				
				if(rayHit.Raycast(ray, out distance))
				{
					Vector3 someVector = ray.GetPoint(distance);
					//Debug.Log (someVector);
					//t
					Vector3 direction = (((someVector - gameObject.transform.localPosition).normalized) * dashDistance);
					//we only want to dash on the x and z so the player doesn't float in the air which is why the y of the destination vector3 is set to 0
					direction.y = floor.transform.position.y;
					Debug.Log ("we are dashing towards" + direction);
					
					
					
					
					Vector3 destination = currPosition + direction;
					
					
					
					
					StartCoroutine(DashLerp (currPosition, destination));
					
					
					//Vector3	destination = direction] * 5;
					
					//destination = destination + gameObject.transform.position;
					
				}
				stamina.Running = false;
			}
			
			//Vector3 someVector = resultsofcast;
			
			//this is making the new variable script reference the move script on the main player. An easy way to reference the move script on the player. This is finding the move script on
			//player
			//this is passing the vector3 variable someVector (the position of the mouse on the screen) to the playerDash function that's in move
			//script.PlayerDash(someVector);
			
			//checks if the mouse button was pressed down. If it was, then wasMouseDown is set to true
			wasMouseDown = true;
		} 
		
		else if (Input.GetMouseButtonUp (1) && wasMouseDown) 
		{
			// Reset
			Debug.Log ("Right mouse up!");
			
			//this is checking if the mouse was let up after it was pressed down and only happens if wasMouseDown was initially true. If the mouse was released and wasMouseDown
			//set to true, then this becomes false
			wasMouseDown = false;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Terrain" && playerState.isDashing == true)
		{
			dashStop = true;
			
			
			
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		
		if(other.gameObject.tag == "Terrain")
		{
			dashStop = false;
			
		}
	}
	
	IEnumerator DashLerp (Vector3 currPosition, Vector3 destination)
		
	{
		//playerCollider.enabled = false;
		float time = 0;
		
		playerState.canAttack = false;
		playerState.isAttacking = false;
		
		playerState.isDashing = true;
		playerState.canDash = false;
		
		
		
		while(transform.position != destination && time <= 1)
		{
			if(dashStop == true)
			{
				destination = playerPosition;
				
			}
			transform.position = Vector3.Lerp (currPosition, destination, time);
			
			time += Time.deltaTime / .15f;
			
			yield return new WaitForEndOfFrame();
		}
		
		playerState.canDash = true;
		playerState.isDashing = false;
		playerState.canAttack = true;
		//playerCollider.enabled = true;
	}
}

