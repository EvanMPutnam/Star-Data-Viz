using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Star : MonoBehaviour {



	public Text text;
	private StarData data;

	// Use this for initialization
	void Start () {
		data = new StarData (transform.position.x, transform.position.y, transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		print("X:" + data.XLoc + " Y:" + data.YLoc + " Z:" + data.ZLoc);
	}

}
