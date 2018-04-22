using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using System.IO;
using System;




//Need to figure out how to implement an Equatorial coordinate system
public class CSV_Viewer : MonoBehaviour {


	/// <summary>
	/// Stores the name for the filepath
	/// Defined in editor
	/// </summary>
	public string filePath;


	/// <summary>
	/// An array of x locations for the stars
	/// </summary>
	private List<float> xLocs;

	/// <summary>
	/// An array of y locations for the stars
	/// </summary>
	private List<float> yLocs;

	/// <summary>
	/// An array of z locations for the stars
	/// </summary>
	private List<float> zLocs;

	/// <summary>
	/// The rgb colors of a given star.
	/// </summary>
	private List<float> magnitude;





	/// <summary>
	/// Ammount of stars to parse from csv.  Defined in editor.
	/// Max is 119615
	/// </summary>
	public int starAmmount;


	/// <summary>
	/// Particle system to create "stars" at given locations.
	/// Defined in editor.
	/// </summary>
	public ParticleSystem partSystem;


	/// <summary>
	/// Private variable for counting stars processed
	/// </summary>
	private int starSize = 0;




	/// <summary>
	/// Start function reads in the csv files and then subsequently creates the stars.
	/// </summary>
	void Start () {
		readCsv ();
		createStars ();
	}






	/// <summary>
	/// Reads the csv file and fills the x, y, z arrays with values
	/// </summary>
	private void readCsv(){

		DateTime d = DateTime.Now;
		using (var reader = new StreamReader (Application.dataPath+"/"+filePath)) {
			xLocs = new List<float>();
			yLocs = new List<float>();
			zLocs = new List<float>();
			magnitude = new List<float> ();
			//colorsRGB = new List<ColorIndex> ();

			int count = 0;
			while (!reader.EndOfStream) {
				var line = reader.ReadLine ();
				var values = line.Split (',');


				if (count != 0 && count < starAmmount) {
					//print (values [16]);


					//Note that y and z coordinates are flipped because unity has a different coordinate system.  Y is up/down
					magnitude.Add(float.Parse(values[13]));
					xLocs.Add (float.Parse (values [17]));
					yLocs.Add (float.Parse (values [19]));
					zLocs.Add (float.Parse (values [18]));
					partSystem.Emit (1);
					starSize += 1;

				} else {
					//print (values [16]);
				}

				if (count == starAmmount) {
					break;
				}

				count += 1;

			}

		}
		//print (DateTime.Now.Second - d.Second );
	}




	/// <summary>
	/// Creates the stars
	/// </summary>
	private void createStars(){
		ParticleSystem.Particle[] arrParts;
		arrParts = new ParticleSystem.Particle[starSize];

		//partSystem.Clear ();
		partSystem.GetParticles (arrParts);

		int count = 0;
		foreach( float x in xLocs){

			ParticleSystem.Particle par = arrParts[count];

			//Normally times a scalar


			//Change the vector to be length 1.  Multiply it by 99% of far clipping value

			if (xLocs [count] != 0.0 && yLocs [count] != 0.0 && zLocs [count] != 0.0) {
				par.position = new Vector3 (
					xLocs [count],
					yLocs [count],
					zLocs [count]
				).normalized * Camera.main.farClipPlane * 0.99f;

			//Gets rid of the sun at center
			} else {
				par.position = new Vector3 (1, 1, 1).normalized * Camera.main.farClipPlane * 1.2f;
			}


			//Increase particle size so we can see it at distance
			par.startSize = 12;


			//Color is based magnitude
			par.startColor = Color.white * (1.0f - (magnitude[count] + 1.40f) / 8) * 2; 

			//par.velocity = Vector3.zero;
			arrParts [count] = par;
			count += 1;
			//print (count);
		}
		//print (count);
		//theParticleSystem.SetParticles (arrParticles, arrParticles.Length);
		//print(starAmmount +" "+starSize);
		partSystem.SetParticles(arrParts, starSize);

	}



	// Update is called once per frame
	void Update () {

	}
}
