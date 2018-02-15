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

	}

}
