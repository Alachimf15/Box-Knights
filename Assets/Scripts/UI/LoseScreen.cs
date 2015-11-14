using UnityEngine;
using System.Collections;

public class LoseScreen : MonoBehaviour 
{	
	// Variables for screen height and width, and button height and width
	[SerializeField]
	private float screenHeight;
	[SerializeField]
	private float screenWidth;
	[SerializeField]
	private float buttonHeight;
	[SerializeField]
	private float buttonWidth;
	
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () 
	{
		screenHeight = Screen.height;	// Height of screen
		screenWidth = Screen.width;		// Width of screen
		
		buttonHeight = screenHeight * 0.14f;	// Height of button
		buttonWidth = screenWidth * 0.2f;	// Width of button
	}
	
	
	/// <summary>
	/// Raises the GU event.
	/// </summary>
	void OnGUI () 
		
	{
		// Make a background box
		// Make the first button. If it is pressed, Application.Loadlevel will be executed
		if(GUI.Button(new Rect((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.47f, buttonWidth, buttonHeight), " "))
			
		{
			Application.LoadLevel(2);
		}
		
	}
}