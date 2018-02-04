using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprt_Movement : MonoBehaviour
{

    public Vector3 startPos;
    
	// Use this for initialization
	void Start ()
    {
        //Setting the starting position
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        DontDestroyOnLoad(this);
        //Checking inputs
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            //If there is nothing in front of the object
            if (Physics2D.Raycast(transform.position, transform.up, transform.up.magnitude).collider == null)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Physics2D.Raycast(transform.position, -transform.up, transform.up.magnitude).collider == null)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (Physics2D.Raycast(transform.position, -transform.right, transform.right.magnitude).collider == null)
            {
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Physics2D.Raycast(transform.position, transform.right, transform.right.magnitude).collider == null)
            {
                transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            }
        }
    }
}
