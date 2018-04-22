using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickControl : MonoBehaviour {


	private const float SPEED = 10;
	private const float zoomSpeed = 50;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		float moveX = Input.GetAxis ("Horizontal");
		float moveY = Input.GetAxis ("Vertical");
		float moveZ = Input.GetAxis ("Diagonal");

		float thrust = Input.GetAxis ("Thrust");


		if (thrust < 1) {

			float speed = -(thrust - 1); 
			transform.position += transform.forward * Time.deltaTime * speed * 10;
		}


		transform.Rotate (moveY, 0, 0);
		transform.Rotate (0, 0, -moveX);
		transform.Rotate (0, moveZ, 0);


	}
}
