using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public bool check;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!check)
            transform.Rotate(0, 1, 0);
        else
            transform.Rotate(-0.2f, 0, 60);
    }
}
