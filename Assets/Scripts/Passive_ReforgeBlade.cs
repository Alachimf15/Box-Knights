using UnityEngine;
using System.Collections;

public class Passive_ReforgeBlade : MonoBehaviour {

	IEnumerator passive;

	public bool passiveActive;


	public float passiveActiveTime;

	public float lengthIncrease;

	public int damageWell;

	public int damageLimit;

	// Use this for initialization

	void OnTriggerEnter(Collider hit)
	{
		if(hit.gameObject.tag == "enemy")
		   {
			damageWell += GetComponent<damage> ().damageNum;

			}

	}




	// Update is called once per frame
		public void CallRoutine()
	{
		if(damageWell >= damageLimit)
		{
				
			passiveActive = true;
		}
				if(passiveActive == true)
				{
					StartCoroutine(Reforge(0f));
		}
				
			else 
			{
			StopCoroutine("Reforge");
			}

				
			

		 if(damageWell < damageLimit)
		{
			passiveActive = false;

			}
		if(passiveActive == false)
		{
			StopCoroutine("Reforge");

		}
}

	IEnumerator Reforge (float passiveActiveTime)
	{
		while(passiveActive = true)
		{
		gameObject.transform.localScale += new Vector3 (lengthIncrease, 0.0f, lengthIncrease);


			print ("this coroutine has started");
			yield return new WaitForSeconds(passiveActiveTime);
			damageWell = 0;
			gameObject.transform.localScale -= new Vector3 (lengthIncrease, 0.0f, lengthIncrease);
		print ("this coroutine is over");
	}
}
}