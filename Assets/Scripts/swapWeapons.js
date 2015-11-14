#pragma strict

private var weaponToggled : boolean;
private var weapon : GameObject[];
private var weaponCount : int;


function Awake(){
weapon = GameObject.FindGameObjectsWithTag("weapon");
weapon[1].gameObject.SetActive (false);
}

function Start () {

print("weapon length is " + weapon.Length);
}

/*
function Update () {
if(Input.GetKeyDown("e"))
{
weaponToggled = !weaponToggled;
}
if(weaponToggled == false)
{
weapon[1].gameObject.SetActive (false);
weapon[1].gameObject.GetComponent.<Collider>().enabled = false;
weapon[0].gameObject.SetActive (true);
}
if(weaponToggled == true)
{
weapon[0].gameObject.SetActive (false);
weapon[0].gameObject.GetComponent.<Collider>().enabled = false;
weapon[1].gameObject.SetActive (true);
}

}

*/