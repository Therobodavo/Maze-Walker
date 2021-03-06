﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    //Variables
    public GameObject player;
    public string nextLvl;
    public bool isLast;

    public Vector3 newPos;
	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (isLast == false)
        {
            //Loading in the next scene
            SceneManager.LoadScene(nextLvl);
            //Resetting the position of the eplayer
            player.transform.position = newPos;
        }

        else
        {
            Destroy(player);
            //Loading in the next scene
            SceneManager.LoadScene(nextLvl);
        }
    }
}
