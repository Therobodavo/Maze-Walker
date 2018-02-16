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
    public bool overAct;
    public bool underAct;



    public Tilemap overMap;
    public Tilemap underMap;

    private GameObject[] player;
    private Vector3Int playerInt;

    private Vector3 initPlayerPos;

    public Vector3 playerSpawn;
    public GameObject[] keys;
    public GameObject[] doors;

    // Use this for initialization
    void Start()
    {
        overAct = true;
        underAct = false;

        keys = GameObject.FindGameObjectsWithTag("Key");
        doors = GameObject.FindGameObjectsWithTag("Door");

        player = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject play in player)
        {
            if (play != player[0])
                Destroy(play);
        }


        initPlayerPos = player[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(overMap.GetTile(playerInt));
        //Getting input to change the worlds
        if (Input.GetKeyDown(KeyCode.E) && !(GameObject.Find("Scanner").GetComponent<Scanner>().scanning))
        {
            //Clear any scanned objects
            GameObject.Find("Scanner").GetComponent<Scanner>().destroyBlocks();

            //Changing which is enabled
            overAct = !overAct;
            underAct = !underAct;

            //overWorld.SetActive(overAct);
            if (overAct)
            {
                overWorld.transform.position = new Vector3(overWorld.transform.position.x, overWorld.transform.position.y, 0);
                overMap.GetComponent<TilemapCollider2D>().enabled = true;
                underWorld.transform.position = new Vector3(underWorld.transform.position.x, underWorld.transform.position.y, 5);
                underMap.GetComponent<TilemapCollider2D>().enabled = false;
            }
            else if (underAct)
            {
                overWorld.transform.position = new Vector3(overWorld.transform.position.x, overWorld.transform.position.y, 5);
                overMap.GetComponent<TilemapCollider2D>().enabled = false;
                underWorld.transform.position = new Vector3(underWorld.transform.position.x, underWorld.transform.position.y, 0);
                underMap.GetComponent<TilemapCollider2D>().enabled = true;
            }
            //underWorld.SetActive(underAct);


            //If the player switches into a world and into a tile
            if (Physics2D.Raycast(player[0].transform.position, player[0].transform.up, .1f).collider == true)
            {
                //Restart the player at their spawn position
                player[0].transform.position = initPlayerPos;
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                //Looping through the array of keys to set them as active
                foreach (GameObject go in keys)
                {
                    go.SetActive(true);
                }

                //Setting all doors to be active
                foreach (GameObject go in doors)
                {
                    go.SetActive(true);
                }
                Movement pScript = (Movement)player[0].GetComponent("Movement");
                pScript.restart();

                overWorld.transform.position = new Vector3(overWorld.transform.position.x, overWorld.transform.position.y, 0);
                overMap.GetComponent<TilemapCollider2D>().enabled = true;
                underWorld.transform.position = new Vector3(underWorld.transform.position.x, underWorld.transform.position.y, 5);
                underMap.GetComponent<TilemapCollider2D>().enabled = false;
            }
        }
    }
}

