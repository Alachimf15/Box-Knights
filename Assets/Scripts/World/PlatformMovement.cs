using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {

    [SerializeField]
    private float speed;

    [Header("Move Using Horizontal or Vertical Increment")]
    [SerializeField]
    private bool isVertical = false;
    [SerializeField]
    private bool isHorizontalX = false;
    [SerializeField]
    private bool isHorizontalZ = false;
    [SerializeField]
    private float incrementValue = 0;
    [SerializeField]
    private bool isLooping = false;
    [SerializeField]
    private bool moveOpposite = false;
    private bool startRegular = false;
    private Vector3 startPosition = Vector3.zero;

    [SerializeField]
    private bool active = false;


	// Use this for initialization
	void Start ()
    {
        startPosition = transform.position;
        if (!moveOpposite)
            startRegular = true;
        else
            startRegular = false;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (active)
        {
      /*      if(!isVertical && !isHorizontalX && !isHorizontalZ)
            {
                // remember, 10 - 5 is 5, so target - position is always your direction.
                Vector3 dir = endTarget.position - transform.position;

                // magnitude is the total length of a vector.
                // getting the magnitude of the direction gives us the amount left to move
                float dist = dir.magnitude;

                // this makes the length of dir 1 so that you can multiply by it.
                dir = dir.normalized;

                // the amount we can move this frame
                float move = speed * Time.deltaTime;

                // limit our move to what we can travel.
                if (move > dist) move = dist;

                // apply the movement to the object.
                transform.Translate(dir * move);
            }*/

            // Alternative way to move objects without a Transform variable but a distance variable - Omer
            if((isVertical || isHorizontalX || isHorizontalZ) && !isLooping)
            {
                if(isVertical && startRegular && transform.position.y <= startPosition.y + incrementValue)
                {
                    Vector3 vertPos = transform.position;
                    vertPos.y += Time.deltaTime * speed;
                    transform.position = vertPos;

                    //Set to inactive once reached target distance
                    if(transform.position.y >= startPosition.y + incrementValue)
                    {
                        ResetObject();
                    }

                }
				else if(isVertical && !startRegular && transform.position.y >= startPosition.y - incrementValue)
				{
					Vector3 vertPos = transform.position;
					vertPos.y -= Time.deltaTime * speed;
					transform.position = vertPos;

                    if (transform.position.y <= startPosition.y - incrementValue)
                    {
                        ResetObject();
                    }
                }
                else if(isHorizontalX && startRegular && transform.position.x <= startPosition.x + incrementValue)
                {
                    Vector3 vertPos = transform.position;
                    vertPos.x += Time.deltaTime * speed;
                    transform.position = vertPos;

                    if (transform.position.x >= startPosition.x + incrementValue)
                    {
                        ResetObject();
                    }
                }
                else if (isHorizontalX && !startRegular && transform.position.x >= startPosition.x - incrementValue)
                {
                    Vector3 vertPos = transform.position;
                    vertPos.x -= Time.deltaTime * speed;
                    transform.position = vertPos;

                    if (transform.position.x <= startPosition.x - incrementValue)
                    {
                        ResetObject();
                    }
                }
                else if (isHorizontalZ && startRegular && transform.position.z <= startPosition.z + incrementValue)
                {
                    Vector3 vertPos = transform.position;
                    vertPos.z += Time.deltaTime * speed;
                    transform.position = vertPos;

                    if (transform.position.z >= startPosition.z + incrementValue)
                    {
                        ResetObject();
                    }
                }
                else if (isHorizontalZ && !startRegular && transform.position.z >= startPosition.z - incrementValue)
                {
                    Vector3 vertPos = transform.position;
                    vertPos.z -= Time.deltaTime * speed;
                    transform.position = vertPos;

                    if (transform.position.z <= startPosition.z - incrementValue)
                    {
                        ResetObject();
                    }
                }
            }
            else if(isLooping && isVertical)
            {
                if(startRegular)
                {
                    MoveVerticalLoop(incrementValue, startPosition.y);
                }
                else
                {
                    MoveVerticalLoop(startPosition.y, incrementValue);
                }
            }
            else if (isLooping && isHorizontalZ)
            {
                if (startRegular)
                {
                    MoveHorizontalZLoop(incrementValue, startPosition.z);
                }
                else
                {
                    MoveHorizontalZLoop(startPosition.z, incrementValue);
                }
            }
			else if (isLooping && isHorizontalX)
			{
				if (startRegular)
				{
					MoveHorizontalXLoop(incrementValue, startPosition.x);
				}
				else
				{
					MoveHorizontalXLoop(startPosition.x, incrementValue);
				}
			}
        }
    }

    private void ResetObject()
    {
        active = false;
        startPosition = transform.position;
    }

    private void MoveVerticalLoop(float value, float value2)
    {
        if (!moveOpposite)
        {
            if (transform.position.y >= value)
            {
                Vector3 vertPos = transform.position;
                vertPos.y -= Time.deltaTime * speed;
                transform.position = vertPos;
            }
            else
                moveOpposite = true;
        }
        else
        {
            if (transform.position.y <= value2)
            {
                Vector3 vertPos = transform.position;
                vertPos.y += Time.deltaTime * speed;
                transform.position = vertPos;
            }
            else
                moveOpposite = false;
        }
    }

    private void MoveHorizontalZLoop(float value, float value2)
    {
        if (!moveOpposite)
        {
            if (transform.position.z >= value)
            {
                Vector3 vertPos = transform.position;
                vertPos.z -= Time.deltaTime * speed;
                transform.position = vertPos;
            }
            else
                moveOpposite = true;
        }
        else
        {
            if (transform.position.z <= value2)
            {
                Vector3 vertPos = transform.position;
                vertPos.z += Time.deltaTime * speed;
                transform.position = vertPos;
            }
            else
                moveOpposite = false;
        }
    }

	private void MoveHorizontalXLoop(float value, float value2)
	{
		if (!moveOpposite)
		{
			if (transform.position.x >= value)
			{
				Vector3 vertPos = transform.position;
				vertPos.x -= Time.deltaTime * speed;
				transform.position = vertPos;
			}
			else
				moveOpposite = true;
		}
		else
		{
			if (transform.position.x <= value2)
			{
				Vector3 vertPos = transform.position;
				vertPos.x += Time.deltaTime * speed;
				transform.position = vertPos;
			}
			else
				moveOpposite = false;
		}
	}

    public void OnPortTriggerable()
    {
        active = true;
    }

    public void OnPortTriggerableDeactivate()
    {
        active = false;
    }
}
