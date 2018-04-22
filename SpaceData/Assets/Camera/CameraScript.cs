using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	private float mnFov = 1f;
	private float mxFov = 90f;
	private float sensitivity = 2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float nFov = Camera.main.fieldOfView;
		nFov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
		nFov = Mathf.Clamp(nFov, mnFov, mxFov);
		Camera.main.fieldOfView = nFov;
	}
}
