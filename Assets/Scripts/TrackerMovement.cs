using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for Tracker enemy
public class TrackerMovement : MonoBehaviour {

    //Variables
    GameObject[] obstacles;

    //start position tracker
  public  Vector3 sPos;

    // last position moved (used to prevent backtracking)
    string laPos;

    //timer for movement
       float timer;

    // total time
   public float totalTime;



    // Use this for initialization
    void Start () {
        sPos = transform.position;
        laPos = "Left";
        timer = 0;
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
    }
	
	// Update is called once per frame
	void Update () {
        timer += 1;
        if (timer > totalTime)
        {
            moveTrack();

        }
           
        
	}

    public bool canMove(Vector3 newPos)
    {
        bool canMove = true;
        foreach (GameObject obs in obstacles)
        {
            Rect obsRect = new Rect(new Vector2(obs.transform.position.x - (obs.transform.localScale.x / 2), obs.transform.position.y - (obs.transform.localScale.y / 2)), new Vector2(obs.transform.localScale.x, obs.transform.localScale.y));
            Rect playerRect = new Rect(new Vector2(newPos.x - (transform.localScale.x / 2), newPos.y - (transform.localScale.y / 2)), new Vector2(transform.localScale.x, transform.localScale.y));
            if (obsRect.Overlaps(playerRect))
            {
                Debug.Log(obsRect.position);
                return false;
            }
        }
        return canMove;
    }

    public bool moveLeft()
    {
        if (canMove(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z)))
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            laPos = "Left";
            return true;
        }
        return false;
    }
    public bool moveRight()
    {
        if (canMove(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z)))
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            laPos = "Right";
            return true;       
        }
        return false;
    }
    public bool moveUp()
    {
        if (canMove(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z)))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            laPos = "Up";
            return true;
        }
        return false;
    }
    public bool moveDown()
    {
        if (canMove(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z)))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            laPos = "Down";
            return true;
        }
        return false;
    }


    public void moveTrack()
    {
        if (laPos == "Right")
        {
            if (moveRight())
                timer = 0;
            else if (moveUp())
                timer = 0;
            else if (moveDown())
                timer = 0;
            else if (moveLeft())
                timer = 0;

        }
        else if(laPos == "Left")
        {
            if (moveLeft())
                timer = 0;
            else if (moveDown())
                timer = 0;
            else if (moveUp())
                timer = 0;
            else if (moveRight())
                timer = 0;

        }
        else if (laPos == "Up")
        {
            if (moveUp())
                timer = 0;
            else if (moveRight())
                timer = 0;
            else if (moveLeft())
                timer = 0;
            else if (moveDown())
                timer = 0;

        }
        else if (laPos == "Down")
        {
            if (moveDown())
                timer = 0;
            else if (moveLeft())
                timer = 0;
            else if (moveRight())
                timer = 0;
            else if (moveUp())
                timer = 0;

        }
    }

}
