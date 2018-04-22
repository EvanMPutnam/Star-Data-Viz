using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MenuNavigation : MonoBehaviour {

	/// <summary>
	/// Defined in editor.  Button for which to add start functions
	/// </summary>
	public Button start;

	public Toggle toggleJoystick;

	public Toggle colorAccurate;





	// Use this for initialization
	void Start () {
		start.onClick.AddListener (updateScenes);
	}
	
	// Update is called once per frame
	void Update () {

				
	}



	void updateScenes(){
		if (colorAccurate.isOn) {
			ParticleCSV.COLOR_ACCURATE = true;
		} else {
			ParticleCSV.COLOR_ACCURATE = false;
		}

		if (toggleJoystick.isOn) {
			MenuScript.JOY_STICK = true;
		} else {
			MenuScript.JOY_STICK = false;
		}

		SceneManager.LoadScene ("LoadingScreen");

	}
}
