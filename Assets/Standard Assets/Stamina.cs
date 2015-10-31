using UnityEngine;
using System.Collections;

public class Stamina : MonoBehaviour 
{
	float stamina = 5, maxStamina = 5, dashStamina = 1;
	//float walkSpeed, runSpeed;
	//MousePickingScript cm;
	bool isRunning;
	
	
	
	Rect staminaRect;
	Texture2D staminaTexture;
	
	MasterPlayerStateScript playerState;
	
	void Start () 
	{
		//cm = gameObject.GetComponent<MousePickingScript> ();
		//walkSpeed = move.movement.maxForwardSpeed;
		//runSpeed = walkSpeed * 3;
		playerState = GetComponent <MasterPlayerStateScript>();
		staminaRect=new Rect(Screen.width/10,Screen.height*9/10, Screen.width / 3, Screen.height / 50);
		staminaTexture = new Texture2D(1, 1);
		staminaTexture.SetPixel(0, 0, Color.white);
		staminaTexture.Apply ();
	}
	
	public bool Running
	{
		get
		{
			return isRunning;
		}
		set
		{
			isRunning = value;
		}
		//cm.movement.maxForwardSpeed = isRunning ? runSpeed : walkSpeed;
	}
	
	void Update () 
	{
		if (stamina >= dashStamina && Running == false && playerState.canDash == true)
		{
			Running = (true);
			stamina -= dashStamina;
			
			if(stamina <= 0)
			{
				stamina = 0;
			}
		}
		
		if (stamina < maxStamina)
		{
			stamina += (Time.deltaTime / 2);
		}
	}
	void OnGUI()
	{
		float ratio = stamina / maxStamina;
		float rectWidth = ratio * Screen.width / 3;
		staminaRect.width = rectWidth;
		GUI.DrawTexture(staminaRect, staminaTexture);
	}
	
}
