using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

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

    public Vector3 playerSpawn;

    public List<GameObject> keys = new List<GameObject>();
    public List<GameObject> doors = new List<GameObject>();

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

        //Debug.Log(overMap.GetTile(playerInt));
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

            //If the player switches into a world and into a tile
            if(Physics2D.Raycast(player.transform.position, player.transform.up, .1f).collider == true)
            {
                //Restart the player at their spawn position
                player.transform.position = initPlayerPos;
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                //Looping through the array of keys to set them as active
                foreach(GameObject go in keys)
                {
                    go.SetActive(true);
                }

                //Setting all doors to be active
                foreach(GameObject go in doors)
                {
                    go.SetActive(true);
                }

                //if the player is switching into the underworld, and dies, switch back to the overworld for the level resetting
                if(underAct)
                {
                    underAct = false;
                    underWorld.SetActive(false);
                    overAct = true;
                    overWorld.SetActive(true);
                }
            }
        }
	}
}
