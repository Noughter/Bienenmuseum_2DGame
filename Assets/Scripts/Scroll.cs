using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

	public float time = 5; //Seconds to read the text

	private GameMaster gm;


	void Start ()
	{   //Initilaize
		gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

		//Versteckt Objekt zu start
		gameObject.GetComponent<Renderer>().enabled = false;
	}

	void Update() 
	{
		if (gm.bienenstockUebrig<=4) {
			// show Scroll wenn nur noch 4 Bienenstöcke
			gameObject.GetComponent<Renderer>().enabled = true;
			Destroy(gameObject, time);
		}
	}
}
