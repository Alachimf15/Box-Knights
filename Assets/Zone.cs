﻿using UnityEngine;
using System.Collections;

public class Zone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



void OnColliderStay(Collider zone)
	{
		if (zone.GetComponent<Collider>().CompareTag("enemyHitDetect"))
			print ("yo");
	}
}