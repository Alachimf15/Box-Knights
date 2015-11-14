using UnityEngine;
using System.Collections;


public class WinScreen : MonoBehaviour 
{
	// Variables for screen height and width, and button height and width
	[SerializeField]
	public float screenHeight;
	[SerializeField]
	public float screenWidth;
	[SerializeField]
	public float buttonHeight;
	[SerializeField]
	public float buttonWidth;
	
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () 
	{
		screenHeight = Screen.height;	// Height of screen
		screenWidth = Screen.width;		// Width of screen
		
		buttonHeight = screenHeight * 0.103f;	// Height of button
		buttonWidth = screenWidth * .1176f;	// Width of button
		
		//screenHeight = 1101.86f;
		//buttonWidth = 185f;
		//screenWidth = 1319.77f;
		
	}
	
	
	/// <summary>
	/// Raises the GU event.
	/// </summary>
	void OnGUI () 
		
	{
		// Make a background box
		// Make the first button. If it is pressed, Application.Loadlevel will be executed
		if(GUI.Button(new Rect((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.638f, buttonWidth, buttonHeight), " "))
			
		{
			Application.LoadLevel(1); //
		}
		
	}
	
}