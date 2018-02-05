using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwitch : MonoBehaviour
{

    public GameObject overWorld;
    public GameObject underWorld;

    //Setting active variables
    private bool overAct;
    private bool underAct;
	// Use this for initialization
	void Start ()
    {
        overAct = true;
        underAct = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		//Getting input to change the worlds
        if(Input.GetKeyDown(KeyCode.E))
        {
            //Changing which is enabled
            overAct = !overAct;
            underAct = !underAct;

            overWorld.SetActive(overAct);
            underWorld.SetActive(underAct);
        }
	}
}
