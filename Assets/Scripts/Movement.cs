using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Variables
    GameObject[] obstacles;

	// Use this for initialization
	void Start ()
    {
	    obstacles = GameObject.FindGameObjectsWithTag("Obstacle");	
	}
	
	// Update is called once per frame
	void Update ()
    {
        getInput();
    }
    public bool canMove(Vector3 newPos)
    {
        bool canMove = true;
        foreach(GameObject obs in obstacles)
        {
            Rect obsRect = new Rect(new Vector2(obs.transform.position.x - (obs.transform.localScale.x / 2),obs.transform.position.y - (obs.transform.localScale.y / 2)),new Vector2(obs.transform.localScale.x,obs.transform.localScale.y));
            Rect playerRect = new Rect(new Vector2(newPos.x - (transform.localScale.x / 2),newPos.y - (transform.localScale.y / 2)),new Vector2(transform.localScale.x,transform.localScale.y));
            if(obsRect.Overlaps(playerRect))
            {
                Debug.Log(obsRect.position);
                return false;
            }
        }
        return canMove;
    }
    public void getInput()
    {
        if(Input.GetKeyDown(KeyCode.D) && canMove(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z)))
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.A) && canMove(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z)))
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.W) && canMove(new Vector3(transform.position.x, transform.position.y +1, transform.position.z)))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y +1, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.S) && canMove(new Vector3(transform.position.x, transform.position.y -1, transform.position.z)))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y -1, transform.position.z);
        }
    }
}
