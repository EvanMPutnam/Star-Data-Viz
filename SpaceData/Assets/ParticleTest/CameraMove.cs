using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {


	public float zoomSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float z = Input.GetAxis ("Mouse ScrollWheel");
		z = z * -1;
		//Helps me with positive forward
		if(transform.position.z < -50 && z > 0){
			Vector3 direction = new Vector3 (0, 0, 1);
			//transform.position += Vector3.forward * Time.deltaTime * speed;
			transform.Translate(direction * Time.deltaTime * zoomSpeed);
		};

		if(transform.position.z > -700 && z < 0){
			Vector3 direction = new Vector3 (0, 0, -1);
			transform.Translate(direction * Time.deltaTime * zoomSpeed);
		}
	}
}
