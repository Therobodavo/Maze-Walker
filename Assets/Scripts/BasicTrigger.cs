using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTrigger : MonoBehaviour
{
    //Variables
    public Material mat1;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //mat1.color = Color.red;
        other.transform.position = new Vector3(-5.5f,-2.5f,0);
    }

    private void OnTriggerExit(Collider other)
    {
        //mat1.color = Color.yellow;
    }
}
