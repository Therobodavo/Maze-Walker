using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for Tracker enemy
public class TrackerMovement : MonoBehaviour {

    //Variables
    GameObject[] obstacles;

    GameObject player;

    //start position tracker
    public Vector3 sPos;

    public bool currentWorld;
    // last position moved (used to prevent backtracking)
    string laPos;

    //timer for movement
    float timer;

    // total time
    public float totalTime;

    public WorldSwitch WorldSwitch;

    public bool active;

    // Use this for initialization
    void Start()
    {
        sPos = transform.position;
        laPos = "Left";
        timer = 0;
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        player = GameObject.FindGameObjectWithTag("Player");
        WorldSwitch = (WorldSwitch)GameObject.FindGameObjectWithTag("WorldSwitch").GetComponent("WorldSwitch");

    }

    // Update is called once per frame
    void Update()
    {
       SpriteRenderer rend = (SpriteRenderer)GetComponent("SpriteRenderer");


        if (active)
        {
            timer += 1;
            if (timer > totalTime)
            {
                moveTrack();

            }
        }


        if ((WorldSwitch.overAct && currentWorld) || (WorldSwitch.underAct && !currentWorld))
        {
            active = true;
            gameObject.layer = 0;
        }
        if ((!WorldSwitch.overAct && currentWorld) || (!WorldSwitch.underAct && !currentWorld))
        {
            active = false;
            gameObject.layer = 8;
        }


        if (!active)
        {
            rend.enabled = false;
        }
        else
        {
            rend.enabled = true;
        }
    }



    public bool moveLeft()
    {
        if (Physics2D.Raycast(transform.position, -transform.right, transform.right.magnitude).collider == null)
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            laPos = "Left";
            return true;
        }
        return false;
    }
    public bool moveRight()
    {
        if (Physics2D.Raycast(transform.position, transform.right, transform.right.magnitude).collider == null)
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            laPos = "Right";
            return true;
        }
        return false;
    }
    public bool moveUp()
    {
        if (Physics2D.Raycast(transform.position, transform.up, transform.up.magnitude).collider == null)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            laPos = "Up";
            return true;
        }
        return false;
    }
    public bool moveDown()
    {
        if (Physics2D.Raycast(transform.position, -transform.up, transform.up.magnitude).collider == null)
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
        else if (laPos == "Left")
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
