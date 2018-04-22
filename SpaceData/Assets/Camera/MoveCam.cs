using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour {


	void Update()
	{


		if(Input.GetKey(KeyCode.RightArrow))
		{
			//transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
			transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			//transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
			transform.RotateAround(Vector3.zero, Vector3.down, 20 * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.RotateAround(Vector3.zero, Vector3.forward, 20*Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.RotateAround(Vector3.zero, Vector3.back, 20*Time.deltaTime);
		}
			
	}

}
