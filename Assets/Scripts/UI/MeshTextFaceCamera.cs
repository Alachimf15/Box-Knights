using UnityEngine;
using System.Collections;

public class MeshTextFaceCamera : MonoBehaviour {

	GameObject mainCam;

	// Use this for initialization
	void Start () {
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");

	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(mainCam.transform);
		if(gameObject.tag == "damageText")
		{
			Vector3 currPosition = transform.position;
			Vector3 destination =  new Vector3(currPosition.x, currPosition.y + .65f, currPosition.z);
			
			float time = .2f;
		
			transform.position = Vector3.Slerp(currPosition, destination, time);
			Destroy (gameObject, .3f);

		}
	}


}