using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyScript : MonoBehaviour
{

    public List<GameObject> doors = new List<GameObject>();
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
        //Looping through the connected objects and disabling them
        foreach(GameObject go in doors)
        {
            /*go.GetComponent<MeshRenderer>().enabled = false;
            go.GetComponent<BoxCollider2D>().enabled = false;
            */
            go.SetActive(false);
        }

        //Disabling the key
        this.gameObject.SetActive(false);
    }
}
