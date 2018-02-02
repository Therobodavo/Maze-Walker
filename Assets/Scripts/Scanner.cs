using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour {

    Vector3 startPos;
    Vector3 endPos;

    bool scanStarted = false;
    bool scanning = false;

	// Use this for initialization
	void Start ()
    {
        startPos = transform.GetChild(0).position;
        endPos = transform.GetChild(1).position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            scanning = true;
        }
        Scan();
	}

    void Scan()
    {
        if(scanning)
        {
            if (!scanStarted)
            {
                //Set start position of scanner
                transform.position = startPos;
                scanStarted = true;
            }

            //check if behind
            if (transform.position.x < endPos.x)
            {
                //move
                transform.position += new Vector3(.15f, 0, 0);
                //check objects that are being collided

            }
        }
    }
}
