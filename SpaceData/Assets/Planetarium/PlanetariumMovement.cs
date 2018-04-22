using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetariumMovement : MonoBehaviour {




	public Text text;

	private float RA = 0;//Starts at 6hr
	private float Dec = 0;//



	public float speed;


	// Use this for initialization
	void Start () {
		if (speed == null) {
			speed = 10f;
		}
	}

	// Update is called once per frame
	/**
	void Update () {

		transform.Rotate (Vector3.right * Time.deltaTime);

	}*/

	void Update()
	{


		if(Input.GetKey(KeyCode.UpArrow))
		{
			//transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
			//float location = transform.rotation.y;
			//location -= Time.deltaTime * speed;
			//transform.rotation = Quaternion.Euler(0, location, 0);
			//Quaternion origRot = transform.rotation;
			//transform.rotation = origRot * Quaternion.AngleAxis (1, Vector3.up);
			transform.eulerAngles=new Vector3(transform.eulerAngles.x+(speed*Time.deltaTime),transform.eulerAngles.y,0);

		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			//transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
			//transform.Rotate(Vector3.down * Time.deltaTime * speed);
			//float location = transform.rotation.y;
			//location += Time.deltaTime * speed;
			//transform.rotation = Quaternion.Euler(0, location, 0);
			//Quaternion origRot = transform.rotation;
			//transform.rotation = origRot * Quaternion.AngleAxis (1, Vector3.down);
			transform.eulerAngles=new Vector3(transform.eulerAngles.x-(speed*Time.deltaTime),transform.eulerAngles.y,0);
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.eulerAngles=new Vector3(transform.eulerAngles.x,transform.eulerAngles.y-(speed*Time.deltaTime),0);
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.eulerAngles=new Vector3(transform.eulerAngles.x,transform.eulerAngles.y+(speed*Time.deltaTime),0);
		}


		//Default values for RA is 0.0 and formula sets to 360.
		if (transform.rotation.eulerAngles.y != 0.0f) {
			RA = Mathf.Abs(transform.rotation.eulerAngles.y-360);
		} else {
			RA = 0.0f;
		}

		//Default values for RA is 0.0 and formula sets to 360.
		if (transform.rotation.eulerAngles.x != 0.0f) {
			Dec = Mathf.Abs (transform.rotation.eulerAngles.x - 360);
		} else {
			Dec = 0.0f;
		}


		text.text = "RA: " + RA+"\n"
			+"Dec: "+Dec;





	


	}
}
