using UnityEngine;
using System.Collections;

public class DestroyBarrier : MonoBehaviour {

	public GameObject[] spawners;
	
	void Update()
	{
		for (var i = 0; i < spawners.Length; i++) 
		{
			if(spawners[i] == null)
			{
				Destroy (gameObject);

			}
		}
	}
}