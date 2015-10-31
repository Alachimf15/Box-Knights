using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	//public float deathDistance = 0.5f;
	public float distanceAway;
	public Transform thisObject;
	public Transform target;
	private NavMeshAgent navComponent;

	public string[] enemyAnimations;

	void Start () 
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
		navComponent = this.gameObject.GetComponent<NavMeshAgent>();

		gameObject.GetComponentInChildren<enemyHealth> ().enemy = gameObject;
	}
	

	void Update () 
	{
		if(target)
		{
			navComponent.SetDestination(target.position);
		}
	}

}