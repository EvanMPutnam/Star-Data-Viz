using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {




	public static bool JOY_STICK = false;


	private AsyncOperation asyncV;
	public Text text;

	private const string text1 = "Loading";
	private const string text2 = "Loading.";
	private const string text3 = "Loading..";
	private const string text4 = "Loading...";


	private const int maxFrames = 60;
	private int countFrames;

	// Use this for initialization
	void Start () {
		countFrames = 0;
		if (JOY_STICK == true) {
			StartCoroutine ("CoLoadNextSceneJoyStick");
		} else {
			StartCoroutine ("CoLoadNextScene");
		}
	}
	
	// Update is called once per frame
	void Update () {

		/**
		switch (switchVar) {
			case 1:
				text.text = text1;
				break;
			case 2:
				text.text = text2;
				break;
			case 3:
				text.text = text3;
				break;
			case 4:
				text.text = text4;
				break;
		}
		*/

		if (asyncV != null) {
			//print (asyncV.progress);
			if (asyncV.progress >= 0.90f)
			{
				asyncV.allowSceneActivation = true;
			}
		}
		/**
		if (countFrames == 60) {
			switchVar += 1;
			if (switchVar > 4) {
				switchVar = 1;
			}
			countFrames = 0;
		}
		countFrames += 1;
		*/
	}

	IEnumerator CoLoadNextSceneJoyStick()
	{
		asyncV = EditorSceneManager.LoadSceneAsync ("ParticleTest/Particle");
		asyncV.allowSceneActivation = false;
		yield return asyncV;
	}


	IEnumerator CoLoadNextScene()
	{
		asyncV = EditorSceneManager.LoadSceneAsync ("ParticleTest/ParticleNoJoy");
		asyncV.allowSceneActivation = false;
		yield return asyncV;
	}



}
