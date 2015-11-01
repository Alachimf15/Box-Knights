using UnityEngine;
using System.Collections;

public class Wizard : MonoBehaviour 
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

		distanceAway = Vector3.Distance(target.position, transform.position);
		if(target)
		{
			transform.LookAt (target);
		}

        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

}