using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using System.IO;
using System;



public class ColorIndex {
	public double r;
	public double g;
	public double b;
	public ColorIndex(double r, double g, double b){
		this.r = r;
		this.g = g;
		this.b = b;
	}
}

public class ParticleCSV : MonoBehaviour {





	/// <summary>
	/// Stores the name for the filepath
	/// Defined in editor
	/// </summary>
	public string filePath;



	/// <summary>
	/// Whether or not the stars are color accurate
	/// </summary>
	public static Boolean COLOR_ACCURATE = false;



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
	private List<ColorIndex> colorsRGB;





	/// <summary>
	/// Ammount of stars to parse from csv.  Defined in editor.
	/// Max is 119615
	/// </summary>
	public int starAmmount;

	/// <summary>
	/// Scalar to multiply the x, y, z locations by to spread them out
	/// </summary>
	private float scaler = .8f;



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
			colorsRGB = new List<ColorIndex> ();

			int count = 0;
			while (!reader.EndOfStream) {
				var line = reader.ReadLine ();
				var values = line.Split (',');

			
				if (count != 0 && count < starAmmount) {
					//print (values [16]);

					//If you want color accurate to be true
					if (COLOR_ACCURATE == true) {
						if (values [16] == "") {
							colorsRGB.Add (null);
						} else {
							colorsRGB.Add (bv2rgb (double.Parse (values [16])));
						}
					}



					//Note that y and z coordinates are flipped because unity has a different coordinate system.  Y is up/down
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
		partSystem.GetParticles (arrParts);

		int count = 0;
		foreach( float x in xLocs){
			ParticleSystem.Particle par = arrParts[count];
			par.position = new Vector3(
				xLocs[count] * scaler, 
				yLocs[count] * scaler, 
				zLocs[count] * scaler
			);



			//If color accurate is true then set true color
			if (COLOR_ACCURATE == true) {
				ColorIndex c = colorsRGB [count];
				if (c != null) {
					par.startColor = new Color ((float)c.r, (float)c.g, (float)c.b);
					//print ((float)c.r+" "+ (float)c.g+" "+(float)c.b);
				} else {
					par.startColor = Color.white;
				}
			}




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





	/// <summary>
	/// Function to get the rgb value of a given star from the BV value
	/// Found here https://stackoverflow.com/questions/21977786/star-b-v-color-index-to-apparent-rgb-color
	/// </summary>
	/// <param name="bv">B-V value for star</param>
	ColorIndex bv2rgb(double bv)    // RGB <0,1> <- BV <-0.4,+2.0> [-]
	{

		//Init vars
		double t;
		double r;
		double g;
		double b;

		r=0.0; g=0.0; b=0.0;

		//If below values correct o make sure they are within range
		if (bv<-0.4)
			bv=-0.4; 
		if (bv> 2.0) 
			bv= 2.0;
		
		if ((bv >= -0.40) && (bv < 0.00)) { 
			t = (bv + 0.40) / (0.00 + 0.40);
			r = 0.61 + (0.11 * t) + (0.1 * t * t); 
		} else if ((bv >= 0.00) && (bv < 0.40)) {
			t = (bv - 0.00) / (0.40 - 0.00);
			r = 0.83 + (0.17 * t);
		} else if ((bv >= 0.40) && (bv < 2.10)) {
			t = (bv - 0.40) / (2.10 - 0.40);
			r = 1.00;
		}
		if ((bv >= -0.40) && (bv < 0.00)) {
			t = (bv + 0.40) / (0.00 + 0.40);
			g = 0.70 + (0.07 * t) + (0.1 * t * t);
		} else if ((bv >= 0.00) && (bv < 0.40)) {
			t = (bv - 0.00) / (0.40 - 0.00);
			g = 0.87 + (0.11 * t);
		} else if ((bv >= 0.40) && (bv < 1.60)) {
			t = (bv - 0.40) / (1.60 - 0.40);
			g = 0.98 - (0.16 * t);
		} else if ((bv >= 1.60) && (bv < 2.00)) {
			t = (bv - 1.60) / (2.00 - 1.60);
			g = 0.82 - (0.5 * t * t);
		}
		if ((bv >= -0.40) && (bv < 0.40)) {
			t = (bv + 0.40) / (0.40 + 0.40);
			b = 1.00;
		} else if ((bv >= 0.40) && (bv < 1.50)) {
			t = (bv - 0.40) / (1.50 - 0.40);
			b = 1.00 - (0.47 * t) + (0.1 * t * t);
		} else if ((bv >= 1.50) && (bv < 1.94)) {
			t = (bv - 1.50) / (1.94 - 1.50);
			b = 0.63 - (0.6 * t * t);
		}

		//print ("Red: " + r + ", Green: "+ g + ", Blue: " + b);
		return new ColorIndex (r, g, b);
	}



	// Update is called once per frame
	void Update () {

	}
}
