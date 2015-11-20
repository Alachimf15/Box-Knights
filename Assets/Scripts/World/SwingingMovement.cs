﻿using UnityEngine;
using System.Collections;

public class SwingingMovement : MonoBehaviour {

    public float speed;
    public float loopTime;
    public float desiredRotation;
    public bool isLooping;
    public bool moveOpposite;
    private bool startNormally;
    private float time;
    private float startRotation;
    private float currentRotation;

    public bool active = false;

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
                    Debug.Log("entering RotationLoop with start, desired " + startRotation + desiredRotation);
                    RotationLoop(startRotation, desiredRotation);
            }
        }
	}

    private void RotationLoop(float value1, float value2)
    {

        time = time + Time.deltaTime;
        float phase = Mathf.Sin(time / loopTime);
        transform.localRotation = Quaternion.Euler(new Vector3(phase * desiredRotation, 0, 0));
        /**if(!moveOpposite)
        {
            if (transform.rotation.eulerAngles.x < value2)
            {
                currentRotation += (Time.deltaTime * (speed * 3));
                transform.localRotation = Quaternion.Euler(currentRotation, 0, 0);
            }
            else
                moveOpposite = true;
        }
        else
        {
            if (transform.rotation.eulerAngles.x > value1)
            {
                currentRotation -= (Time.deltaTime * (speed * 3));
                transform.localRotation = Quaternion.Euler(currentRotation, 0, 0);
            }
            else
                moveOpposite = false;
        }**/
    }

    public void ToggleActivate()
    {
        if (active)
            active = false;
        else
            active = true;
    }
}
