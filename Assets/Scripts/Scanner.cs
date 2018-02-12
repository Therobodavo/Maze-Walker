using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour {

    Vector3 startPos;
    Vector3 endPos;

    bool scanStarted = false;
    bool scanning = false;

    List<GameObject> blocks;
    List<int> objsFound;
    public GameObject whiteBlock;
    public GameObject overworld;
    public GameObject underworld;
    public float secDelay = 2;
    float timeLastEnded = -5;

	// Use this for initialization
	void Start ()
    {
        blocks = new List<GameObject>();
        objsFound = new List<int>();
        whiteBlock.transform.position = new Vector3(-100,-100,-100);

        startPos = transform.GetChild(0).position;
        endPos = transform.GetChild(1).position;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.L) && Time.time - timeLastEnded > (secDelay + 1))
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
                scanStarted = true;
            }

            //check if behind
            if (transform.position.x < endPos.x)
            {
                //move
                transform.position += new Vector3(.15f, 0, 0);
                if(underworld.activeInHierarchy)
                {
                    for(int i = 0; i < overworld.transform.childCount;i++) 
                    {
                        if(overworld.transform.GetChild(i).tag == "Key" || overworld.transform.GetChild(i).tag == "FlipTrap" || overworld.transform.GetChild(i).tag == "Enemy" &&
                           overworld.transform.GetChild(i).GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds) && objsFound.IndexOf(overworld.transform.GetChild(i).GetInstanceID()) != -1)
                        {
                            whiteBlock.transform.position = overworld.transform.GetChild(i).transform.position;
                            whiteBlock.transform.position += new Vector3(0, 0, -1);
                            whiteBlock.transform.localScale = overworld.transform.GetChild(i).transform.localScale;
                            blocks.Add(Instantiate(whiteBlock));
                            objsFound.Add(overworld.transform.GetChild(i).GetInstanceID());
                        }
                    }
                }
                else if(overworld.activeInHierarchy)
                {
                    for(int i = 0; i < underworld.transform.childCount;i++) 
                    {
                        if(underworld.transform.GetChild(i).tag == "Key" || underworld.transform.GetChild(i).tag == "FlipTrap" || underworld.transform.GetChild(i).tag == "Enemy" &&
                           underworld.transform.GetChild(i).GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds) && objsFound.IndexOf(underworld.transform.GetChild(i).GetInstanceID()) != -1)
                        {
                            whiteBlock.transform.position = underworld.transform.GetChild(i).transform.position;
                            whiteBlock.transform.position += new Vector3(0, 0, -1);
                            whiteBlock.transform.localScale = underworld.transform.GetChild(i).transform.localScale;
                            blocks.Add(Instantiate(whiteBlock));
                            objsFound.Add(underworld.transform.GetChild(i).GetInstanceID());
             
                        }
                        
                    }
                }
            }
            else
            {
                timeLastEnded = Time.time;
                scanning = false;
                scanStarted = false;
            }
        }
        if (Time.time - timeLastEnded >= secDelay && !scanning)
        {
            foreach (GameObject b in blocks)
            {
                Destroy(b);
            }
        }
    }
}
