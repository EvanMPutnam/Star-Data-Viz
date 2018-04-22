using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {



	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	/**
	void Update () {

		transform.Rotate (Vector3.right * Time.deltaTime);

	}*/

	void Update()
	{


		if(Input.GetKey(KeyCode.RightArrow))
		{
			//transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
			transform.Rotate(Vector3.up * Time.deltaTime * speed, Space.World);
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			//transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
			transform.Rotate(Vector3.down * Time.deltaTime * speed, Space.World);
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.Rotate(Vector3.left * Time.deltaTime * speed, Space.World);
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Rotate(Vector3.right * Time.deltaTime * speed, Space.World);
		}
			

	}
}
