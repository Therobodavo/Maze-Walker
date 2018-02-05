using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour {

    Vector3 startPos;
    Vector3 endPos;

    bool scanStarted = false;
    bool scanning = false;

    GameObject[] enemies;
    GameObject[] traps;
    GameObject[] keys;
    List<GameObject> blocks;
    List<GameObject> objsFound;
    public GameObject whiteBlock;

	// Use this for initialization
	void Start ()
    {
        blocks = new List<GameObject>();
        objsFound = new List<GameObject>();
        whiteBlock.transform.position = new Vector3(-100,-100,-100);

        startPos = transform.GetChild(0).position;
        endPos = transform.GetChild(1).position;

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        traps = GameObject.FindGameObjectsWithTag("FlipTrap");
        keys = GameObject.FindGameObjectsWithTag("Key");
        Debug.Log(traps[4].transform.position);
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

                objsFound.Clear();
                enemies = GameObject.FindGameObjectsWithTag("Enemy");
                traps = GameObject.FindGameObjectsWithTag("FlipTrap");
                keys = GameObject.FindGameObjectsWithTag("Key");
                scanStarted = true;
            }

            //check if behind
            if (transform.position.x < endPos.x)
            {
                //move
                transform.position += new Vector3(.15f, 0, 0);
                //check objects that are being collided
                foreach(GameObject obj in enemies)
                {
                    if(obj.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds) && objsFound.IndexOf(obj) == -1)
                    {
                        whiteBlock.transform.position = obj.transform.position;
                        whiteBlock.transform.localScale = obj.transform.localScale;
                        blocks.Add(Instantiate(whiteBlock));
                        objsFound.Add(obj);
                    }
                }
                foreach(GameObject obj in traps)
                {
                    if(obj.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds) && objsFound.IndexOf(obj) == -1)
                    {
                        whiteBlock.transform.position = obj.transform.position;
                        whiteBlock.transform.localScale = obj.transform.localScale;
                        blocks.Add(Instantiate(whiteBlock));
                        objsFound.Add(obj);
                    }
                }
                foreach(GameObject obj in keys)
                {
                    if(obj.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds) && objsFound.IndexOf(obj) == -1)
                    {
                        whiteBlock.transform.position = obj.transform.position;
                        whiteBlock.transform.localScale = obj.transform.localScale;
                        blocks.Add(Instantiate(whiteBlock));
                        objsFound.Add(obj);
                    }
                }
            }
            else
            {
                foreach(GameObject b in blocks)
                {
                    Destroy(b);
                }
                scanning = false;
                scanStarted = false;
            }
        }
    }
}
