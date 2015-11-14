using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class blockers : MonoBehaviour {

	public List<GameObject> enemies;

	// Use this for initialization
	void Awake () {
		enemies = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if(enemies.Count == 0)
		{
			Destroy (this.gameObject);

		}
	
	}
}
