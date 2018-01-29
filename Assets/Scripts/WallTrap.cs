using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrap : MonoBehaviour {

    //Variables
    public GameObject wallTraper;
    public GameObject player;

    //starting positions
   public  Vector3 sPos;
    public Vector3 sTrapperPos;

    //player movement script
    Movement mScript;

    //movement timer
   float timer;

    //total time
    public float timerTotal;

    //
	// Use this for initialization
	void Start () {
        mScript = (Movement)player.GetComponent("Movement");
        sPos = transform.position;
        sTrapperPos = wallTraper.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        timer++;
        followPlayer();
	}

    public void followPlayer()
    {
        if(mScript.cMoved == true)
        {
            if(player.transform.position.y < transform.position.y && timer > timerTotal)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
                wallTraper.transform.position =  new Vector3(wallTraper.transform.position.x - 1, wallTraper.transform.position.y, wallTraper.transform.position.z);
                timer = 0;
            }
            else if(player.transform.position.y > transform.position.y && timer > timerTotal)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                wallTraper.transform.position = new Vector3(wallTraper.transform.position.x + 1, wallTraper.transform.position.y, wallTraper.transform.position.z);
                timer = 0;
            }
        }
    }
}
