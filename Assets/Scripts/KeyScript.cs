using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {

    //References
    GameObject player;
    BoxCollider playerBox;
    public MeshRenderer[] keyParts;

    //Variables
    public bool Active;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerBox = (BoxCollider)player.GetComponent("BoxCollider");
        Active = true;
    }
	
	// Update is called once per frame
	void Update () {
        Rect playerRect = new Rect(new Vector2(player.transform.position.x - (player.transform.localScale.x / 2), player.transform.position.y - (player.transform.localScale.y / 2)), new Vector2(player.transform.localScale.x, player.transform.localScale.y));
        Rect keyRect = new Rect(new Vector2(transform.position.x - (transform.localScale.x / 2), transform.position.y - (transform.localScale.y / 2)), new Vector2(transform.localScale.x, transform.localScale.y));
        if (keyRect.Overlaps(playerRect))
        {
            Active = false;
            foreach (MeshRenderer ele in keyParts)
            {
                ele.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
      
       
          
           
           
        
    }
}
