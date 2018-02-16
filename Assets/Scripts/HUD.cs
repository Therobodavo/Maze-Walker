using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find("Canvas").transform.GetChild(0).GetComponent<Text>().text = "Scans Left: " + GameObject.Find("Scanner").GetComponent<Scanner>().numScans;;
	}
}
