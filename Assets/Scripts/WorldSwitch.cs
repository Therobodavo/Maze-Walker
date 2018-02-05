using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldSwitch : MonoBehaviour
{

    public GameObject overWorld;
    public GameObject underWorld;

    //Setting active variables
    private bool overAct;
    private bool underAct;

    public Tilemap overMap;
    public Tilemap underMap;

    private GameObject player;
    private Vector3Int playerInt;

    private Vector3 initPlayerPos;
	// Use this for initialization
	void Start ()
    {
        overAct = true;
        underAct = false;

        player = GameObject.Find("Player");
        initPlayerPos = player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        playerInt = new Vector3Int((int)(player.transform.position.x +.5), (int)(player.transform.position.y +.5), (int)player.transform.position.z);

        Debug.Log(overMap.GetTile(playerInt));
		//Getting input to change the worlds
        if(Input.GetKeyDown(KeyCode.E))
        {
            //Changing which is enabled
            overAct = !overAct;
            underAct = !underAct;

            overWorld.SetActive(overAct);
            underWorld.SetActive(underAct);
            /*
            //Checking for player death 
            if(overAct)
            {
                if(overMap.GetTile(playerInt))
                {
                    player.transform.position = initPlayerPos;
                }
            }
            else if (overAct)
            {
                if (underMap.GetTile(playerInt))
                {
                    player.transform.position = initPlayerPos;
                }
            }
            */
        }
	}

    public bool CheckTile(ITilemap itm, Vector3Int pos)
    {
        return itm.GetTile(pos) == this;
    }
}
