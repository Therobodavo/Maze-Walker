using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour {

    //Start and End Points
    Vector3 startPos;
    Vector3 endPos;

    //Variables Used
    bool scanStarted = false;
    public bool scanning = false;
    public float secDelay = 1;
    float timeLastEnded = -5;
    public float speed = 0;
    public int numScans = 3;

    //References
    public List<GameObject> blocks;
    public GameObject whiteBlock;
    List<Collider> scanned;

	// Use this for initialization
	void Start ()
    {
        blocks = new List<GameObject>();
        scanned = new List<Collider>();
        whiteBlock.transform.position = new Vector3(-100,-100,-100);

        startPos = transform.GetChild(0).position;
        endPos = transform.GetChild(1).position;

    }
	
	// Update is called once per frame
	void Update ()
    {
        //If Can Scan
        if (Input.GetKeyDown(KeyCode.Q) && Time.time - timeLastEnded > (secDelay + 1) && numScans > 0)
        {
            scanning = true;
        }
        Scan();
	}

    //Gets objects in othe world when hit
     void OnTriggerEnter(Collider other)
    {
        if(scanned.IndexOf(other) == -1) 
        {
            scanned.Add(other);
            whiteBlock.transform.position = other.transform.position;
            whiteBlock.transform.position = new Vector3(whiteBlock.transform.position.x, whiteBlock.transform.position.y, -.3f);
            blocks.Add(Instantiate(whiteBlock));
        }
    }

    //Main Scan
    void Scan()
    {
        if(scanning)
        {
            if (!scanStarted)
            {
                //Set start position of scanner
                transform.position = startPos;
                scanned.Clear();
                GetComponent<Rigidbody>().AddForce(Vector3.right * speed, ForceMode.VelocityChange);
                scanStarted = true;
                numScans--;
            }

            //check if behind
            if (transform.position.x >= endPos.x)
            {
                timeLastEnded = Time.time;
                scanning = false;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                scanStarted = false;
            }
        }
        if (Time.time - timeLastEnded >= secDelay && !scanning)
        {
            destroyBlocks();
        }
    }

    //Reset Blocks
    public void destroyBlocks() 
    {
        foreach (GameObject b in blocks)
        {
            Destroy(b);
        } 
    }
}
