using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   //Variables
    GameObject[] obstacles;
  public GameObject[] enemies;
    GameObject[] flipTraps;
    GameObject[] wallTraps;
    public GameObject[] keys;
    public GameObject[] doors;


    //start position player
    Vector3 sPos;


    //Bool for checking if the player just flipped worlds
    bool swapped;




    // Use this for initialization
    void Start()
    {
        keys = GameObject.FindGameObjectsWithTag("Key");
        doors = GameObject.FindGameObjectsWithTag("Door");
        sPos = transform.position;
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        flipTraps = GameObject.FindGameObjectsWithTag("FlipTrap");
        wallTraps = GameObject.FindGameObjectsWithTag("WallTrap");
 

        swapped = false;

    }

    // Update is called once per frame
    void Update()
    {
        isAlive();
        DontDestroyOnLoad(this);
        getInput();
    }
    public void restart()
    {
        foreach (GameObject ob in enemies)
        {
            TrackerMovement eScript = (TrackerMovement)ob.GetComponent("TrackerMovement");
            if (eScript.active)
            {
                eScript.transform.position = eScript.sPos;
                transform.position = sPos;
            }
            /*SeekerMovement eScript2 = (SeekerMovement)ob.GetComponent("SeekerMovement");
            if (eScript2.active)
            {
                eScript2.transform.position = eScript2.sPos;
                transform.position = sPos;
            }
            */
        }
    }
    public void isAlive()
    {
        foreach (GameObject obs in enemies)
        {
            Rect obsRect = new Rect(new Vector2(obs.transform.position.x - (obs.transform.localScale.x / 2), obs.transform.position.y - (obs.transform.localScale.y / 2)), new Vector2(obs.transform.localScale.x, obs.transform.localScale.y));
            Rect playerRect = new Rect(new Vector2(transform.position.x - (transform.localScale.x / 2), transform.position.y - (transform.localScale.y / 2)), new Vector2(transform.localScale.x, transform.localScale.y));
            if (obsRect.Overlaps(playerRect) && (TrackerMovement)obs.GetComponent("TrackerMovement"))
            {
                TrackerMovement eScript = (TrackerMovement)obs.GetComponent("TrackerMovement");
                if (eScript.active)
                {
                    restart();
                }


            }
            if (obsRect.Overlaps(playerRect) && (SeekerMovement)obs.GetComponent("SeekerMovement"))
            {
                SeekerMovement eScript = (SeekerMovement)obs.GetComponent("SeekerMovement");
                if (eScript.active)
                {
                    restart();
                }

            }

            //Looping through the array of keys to set them as active
            foreach (GameObject go in keys)
            {
                go.SetActive(true);
            }

            //Setting all doors to be active
            foreach (GameObject go in doors)
            {
                go.SetActive(true);
            }
        }


        /*
        foreach (GameObject obs in wallTraps)
        {
            Rect obsRect = new Rect(new Vector2(obs.transform.position.x - (obs.transform.localScale.x / 2), obs.transform.position.y - (obs.transform.localScale.y / 2)), new Vector2(obs.transform.localScale.x, obs.transform.localScale.y));
            Rect playerRect = new Rect(new Vector2(transform.position.x - (transform.localScale.x / 2), transform.position.y - (transform.localScale.y / 2)), new Vector2(transform.localScale.x, transform.localScale.y));
            if (obsRect.Overlaps(playerRect))
            {             
            
            }
        }
        if (swapped == true)
        {
            foreach (GameObject obs in flipTraps)
            {
                Rect obsRect = new Rect(new Vector2(obs.transform.position.x - (obs.transform.localScale.x / 2), obs.transform.position.y - (obs.transform.localScale.y / 2)), new Vector2(obs.transform.localScale.x, obs.transform.localScale.y));
                Rect playerRect = new Rect(new Vector2(transform.position.x - (transform.localScale.x / 2), transform.position.y - (transform.localScale.y / 2)), new Vector2(transform.localScale.x, transform.localScale.y));
                if (obsRect.Overlaps(playerRect))
                {                  
                   
                }
            }
        }
        */

    }


    public void getInput()
    {


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
