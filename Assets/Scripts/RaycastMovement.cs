using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMovement : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Physics.Raycast(transform.position, transform.up, transform.up.magnitude) == false)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Physics.Raycast(transform.position, -transform.up, transform.up.magnitude) == false)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (Physics.Raycast(transform.position, -transform.right, transform.right.magnitude) == false)
            {
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Physics.Raycast(transform.position, transform.right, transform.right.magnitude) == false)
            {
                transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            }
        }
    }
}
