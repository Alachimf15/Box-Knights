using UnityEngine;
using System.Collections;

//this is a script which will have the enemy track the player and attempt to hit him if he's in range of their attack radius
public class WizardDoDamage : MonoBehaviour 
{
	public int timeToAttack;

	public float attackRange;

	bool isAttacking;

	bool playerInRange;

	bool trackingPlayer;

    bool canAttack = true;

	public string[] enemyAttackAnimations;

	public string[] enemyOtherAnimations;

	public GameObject enemyWeapon;

	GameObject enemyHitDetect;

	GameObject Player;

	public Transform target;

    public GameObject fireball; 

	Wizard FindEnemyScript;
	
	void Start () 
	{
		//finds the palyer's transform in order to follow him
		Player = GameObject.FindGameObjectWithTag ("Player");
		target = Player.transform;
        fireball = GameObject.Find("Fireball");

		FindEnemyScript = this.GetComponent<Wizard> ();

		enemyWeapon = transform.Find("body/arm_bicecp_right/arm_forearm_right/Hand_Right/WizardStaff").gameObject;
                                                     

        //Debug.Log (enemyWeapon.name);
        gameObject.GetComponent<Animation>().CrossFade(enemyOtherAnimations[0], .1f);
        FindEnemyScript.enabled = true;
	}

	/**void OnTriggerEnter(Collider other) 
	{
		//if the object that entered the attack radius is the player, then the player is in range to be attacked
		if (other.gameObject.tag == "Player")
		{
			playerInRange = true;

			if(hasHit == false)
			{

				StartCoroutine(Attack (other.gameObject));
			}
			if(other.gameObject.tag == "weapon")
			{

				print ("got hit yo");
			}

		}

	}**/

	IEnumerator Attack(GameObject Player)
	{
		//plays the attack animation
		gameObject.GetComponent<Animation> ().CrossFade (enemyAttackAnimations [0], .2f);
		gameObject.GetComponent<Animation> ().PlayQueued (enemyAttackAnimations[1]);
		gameObject.GetComponent<Animation> ().PlayQueued (enemyAttackAnimations [2]);
		//print ("You have hit the player, he currently has " + ph.currHealth + " health");

        if(canAttack == true)
        {
            print("attacking player with ranged");
            canAttack = false;

            GameObject fireballClone = Instantiate(fireball, enemyWeapon.transform.position, Quaternion.identity) as GameObject;
            WizardFireball fireballScript = fireballClone.GetComponent<WizardFireball>();
            fireballScript.master = false;
            Destroy(fireballClone, 5);

            yield return new WaitForSeconds(timeToAttack);

            canAttack = true;
        }
        


		


		
	}

	void Update ()
	{

		if (Vector3.Distance(target.position, transform.position) <= attackRange) {
			print ("player in range");

			playerInRange = true;
            StartCoroutine(Attack(Player));
        }

		if (FindEnemyScript.enabled == true) 
		{
			trackingPlayer = true;
		}
		else
		{
			trackingPlayer = false;
		}

		if(trackingPlayer == true)
		{

				gameObject.GetComponent <Animation>().CrossFade (enemyOtherAnimations[0], .1f);
		}
		else
		{
			gameObject.GetComponent <Animation>().Stop (enemyOtherAnimations[0]);
		}

		if(gameObject.GetComponent <Animation>().IsPlaying (enemyAttackAnimations[1]))
		{

			enemyWeapon.GetComponent<Collider>().enabled = true;
		}
		else
		{
			enemyWeapon.GetComponent<Collider>().enabled = false;
		}
	}
}