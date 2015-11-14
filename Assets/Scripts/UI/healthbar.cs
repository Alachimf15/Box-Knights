using UnityEngine;
using System.Collections;

public class healthbar : MonoBehaviour 
{
	GameObject player;

	Rect healthRect;
	Texture2D healthTexture;


	public playerHealth player_Health;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		player_Health = player.gameObject.GetComponent <playerHealth> ();
		healthRect=new Rect(Screen.width/10,Screen.height*8/10, Screen.width / 3, Screen.height / 50);
		healthTexture = new Texture2D(1, 1);
		healthTexture.SetPixel(0, 0, Color.green);
		healthTexture.Apply ();
	}
	void Update()
	{


	}
	
	void OnGUI()
	{
		float ratio = (float)((float)player_Health.currHealth / (float)player_Health.maxHealth);
		Debug.Log ("your healthbar should be looking at this " + ratio);
		float rectWidth = ratio * Screen.width / 3;
		healthRect.width = rectWidth;
		GUI.DrawTexture(healthRect, healthTexture);
	}
}
