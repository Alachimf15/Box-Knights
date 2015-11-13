using UnityEngine;
using System.Collections;

public class SwingingAxes : MonoBehaviour {

    public float speed;
    public float desiredRotation;
    public bool isLooping;
    public bool moveOpposite;
    private bool startNormally;
    public float startRotation;
    public float currentRotation;

    public bool active = false;

    public float trackRot;

	// Use this for initialization
	void Start () {
        startRotation = transform.rotation.eulerAngles.x;
        currentRotation = startRotation;
        if (!moveOpposite)
            startNormally = true;
        else
            startNormally = false;
	}
	
	// Update is called once per frame
	void Update () {

        trackRot = transform.rotation.eulerAngles.x;
	    if (active)
        {
            if (!isLooping)
            {
                if (transform.rotation.eulerAngles.x <= startRotation + desiredRotation && startNormally)
                {
                    currentRotation += Time.deltaTime * (speed * 3);
                    transform.rotation = Quaternion.Euler(currentRotation, 0, 0);
                }
            }
            else
            {
                if(startNormally)
                {
                    Debug.Log("entering RotationLoop with desired, start " + desiredRotation + startRotation);
                    RotationLoop(desiredRotation, startRotation);
                }
                else
                {
                    Debug.Log("entering RotationLoop with start, desired " + startRotation + desiredRotation);
                    RotationLoop(startRotation, desiredRotation);
                }
            }
        }
	}

    private void RotationLoop(float value1, float value2)
    {
        if(!moveOpposite)
        {
            Debug.Log(moveOpposite);
            if (transform.rotation.eulerAngles.x <= value1)
            {
                Debug.Log("performing rotation <= value1 " + value1);
                currentRotation += Time.deltaTime * (speed * 3);
                transform.rotation = Quaternion.Euler(currentRotation, 0, 0);
            }
            else
                moveOpposite = true;
        }
        else
        {
            Debug.Log(moveOpposite);
            if (transform.rotation.eulerAngles.x >= value2)
            {
                Debug.Log("performing rotation >= value2 " + value2);
                currentRotation -= Time.deltaTime * (speed * 3);
                transform.rotation = Quaternion.Euler(currentRotation, 0, 0);
            }
            else
                moveOpposite = false;
        }
    }

    public void ToggleActivate()
    {
        if (active)
            active = false;
        else
            active = true;
    }
}
