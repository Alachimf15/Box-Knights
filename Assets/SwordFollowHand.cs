using UnityEngine;
using System.Collections;

public class SwordFollowHand : MonoBehaviour {

	public Transform hand;

	// Use this for initialization
	void Start () {
		hand = GameObject.FindGameObjectWithTag ("Hand_Left").transform;
		gameObject.transform.parent = hand.transform;
		}
	}