using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Variables
    GameObject[] obstacles;
    GameObject[] enemies;
    GameObject[] flipTraps;
    GameObject[] wallTraps;
    GameObject[] door;

    //Main Camera
    public  Camera mCamera;

    //camera bool
   public  bool cMoved;

    //start position player
    Vector3 sPos;

    //start postion camera
    Vector3 cPos;

    //Bool for checking if the player just flipped worlds
    bool swapped;

    //float for checking which world the players in
    float world;

	// Use this for initialization
	void Start ()
    {
        sPos = transform.position;
        cPos = mCamera.transform.position;
        cMoved = false;
	    obstacles = GameObject.FindGameObjectsWithTag("Obstacle");	
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
       flipTraps = GameObject.FindGameObjectsWithTag("FlipTrap");
        wallTraps = GameObject.FindGameObjectsWithTag("WallTrap");
        door = GameObject.FindGameObjectsWithTag("Door");
        swapped = false;
       
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

        foreach (GameObject obs in door)
        {
            DoorScript dScript = (DoorScript)obs.GetComponent("DoorScript");
            if (dScript.open == false)
            {
                Rect obsRect = new Rect(new Vector2(obs.transform.position.x - (obs.transform.localScale.x / 2), obs.transform.position.y - (obs.transform.localScale.y / 2)), new Vector2(obs.transform.localScale.x, obs.transform.localScale.y));
                Rect playerRect = new Rect(new Vector2(newPos.x - (transform.localScale.x / 2), newPos.y - (transform.localScale.y / 2)), new Vector2(transform.localScale.x, transform.localScale.y));
                if (obsRect.Overlaps(playerRect))
                {
                    Debug.Log(obsRect.position);
                    return false;
                }
            }
           
        }

        return canMove;
    }

   

    public bool isAlive()
    {  
        foreach (GameObject obs in enemies)
        {
            Rect obsRect = new Rect(new Vector2(obs.transform.position.x - (obs.transform.localScale.x / 2), obs.transform.position.y - (obs.transform.localScale.y / 2)), new Vector2(obs.transform.localScale.x, obs.transform.localScale.y));
            Rect playerRect = new Rect(new Vector2(transform.position.x - (transform.localScale.x / 2), transform.position.y - (transform.localScale.y / 2)), new Vector2(transform.localScale.x, transform.localScale.y));
            if (obsRect.Overlaps(playerRect))
            {          
                return false;
            }
        }
        foreach (GameObject obs in wallTraps)
        {
            Rect obsRect = new Rect(new Vector2(obs.transform.position.x - (obs.transform.localScale.x / 2), obs.transform.position.y - (obs.transform.localScale.y / 2)), new Vector2(obs.transform.localScale.x, obs.transform.localScale.y));
            Rect playerRect = new Rect(new Vector2(transform.position.x - (transform.localScale.x / 2), transform.position.y - (transform.localScale.y / 2)), new Vector2(transform.localScale.x, transform.localScale.y));
            if (obsRect.Overlaps(playerRect))
            {             
                return false;
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
                    return false;
                }
            }
        }
        
        return true;
    }


    public void getInput()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            
        }

        if (Input.GetKeyDown(KeyCode.E) && cMoved == false)
        {
           
            mCamera.transform.position = new Vector3(mCamera.transform.position.x + 50, mCamera.transform.position.y, mCamera.transform.position.z);
            transform.position = new Vector3(transform.position.x + 50, transform.position.y, transform.position.z);
            cMoved = true;
            swapped = true;
       
        }
        else if (Input.GetKeyDown(KeyCode.E) && cMoved == true)
        {
      
            mCamera.transform.position = new Vector3(mCamera.transform.position.x - 50, mCamera.transform.position.y, mCamera.transform.position.z);
            transform.transform.position = new Vector3(transform.position.x - 50, transform.position.y, transform.position.z);
            cMoved = false;
            swapped = true;
         
        }


       
        if (Input.GetKeyDown(KeyCode.D) && canMove(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z)))
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            swapped = false;
        }
        if (Input.GetKeyDown(KeyCode.A) && canMove(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z)))
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            swapped = false;
        }
        if (Input.GetKeyDown(KeyCode.W) && canMove(new Vector3(transform.position.x, transform.position.y +1, transform.position.z)))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y +1, transform.position.z);
            swapped = false;
        }
        if (Input.GetKeyDown(KeyCode.S) && canMove(new Vector3(transform.position.x, transform.position.y -1, transform.position.z)))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y -1, transform.position.z);
            swapped = false;
        }


        if(canMove(transform.position) == false || isAlive() == false)
        {
            transform.position = sPos;
            mCamera.transform.position = cPos;
            cMoved = false;
            foreach (GameObject obs in enemies)
            {
                TrackerMovement enemyScript = (TrackerMovement)obs.GetComponent("TrackerMovement");
                obs.transform.position = enemyScript.sPos;
            }
            foreach (GameObject obs in wallTraps)
            {
                WallTrap wallScript = (WallTrap)obs.GetComponent("WallTrap");
                obs.transform.position = wallScript.sPos;
                wallScript.wallTraper.transform.position = wallScript.sTrapperPos;
            }


        }


    }
}
