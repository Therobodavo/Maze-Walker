using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    // Use this for initialization

    public GameObject[] keys;
    GameObject player;
    public bool open;

	void Start () {
       player = GameObject.FindGameObjectWithTag("Player");
        keys =  GameObject.FindGameObjectsWithTag("Key");
        open = false;
    }
	
	// Update is called once per frame
	void Update () {
        open = true;
		foreach(GameObject ele in keys)
        {
            KeyScript kScript = (KeyScript)ele.GetComponent("KeyScript");
            if (kScript.Active)
                open = false;
        }

        if (open)
        {
            MeshRenderer doorMesh = (MeshRenderer)GetComponent("MeshRenderer");
            BoxCollider col = (BoxCollider)GetComponent("BoxCollider");
            col.enabled = false;
            doorMesh.enabled = false;
        }

	}
}
