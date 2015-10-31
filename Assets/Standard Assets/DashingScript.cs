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

	bool dashStop;

	MasterPlayerStateScript playerState;

	Stamina stamina;

	void Start()
	{
		dashDetector = GameObject.FindGameObjectWithTag ("weaponPrefab");
		playerState = GetComponent <MasterPlayerStateScript>();
		stamina = GetComponent<Stamina> ();
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
			RaycastHit hit;



			//if(Physics.Raycast (target.transform.position, Vector3.up, hit, 500))
			//{


			//}
			if (Physics.Raycast (ray, out hit, 500)) 
			{
				if (hit.collider.gameObject.tag == "Floor") 
				{
					Vector3 someVector = hit.point;
					//Debug.Log (someVector);
					//t
					Vector3 direction = (((someVector - gameObject.transform.position).normalized) * dashDistance);
					//we only want to dash on the x and z so the player doesn't float in the air which is why the y of the destination vector3 is set to 0
					direction.y = 0;
					Debug.Log ("we are dashing towards" + direction);
					
					


					Vector3 destination = currPosition + direction;


										
										
					StartCoroutine(DashLerp (currPosition, destination));
	
			
					//Vector3	destination = direction] * 5;

					//destination = destination + gameObject.transform.position;

				}
				stamina.Running = false;
			}
		
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

void OnTriggerStay(Collider other)
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

