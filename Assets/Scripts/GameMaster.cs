using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	public int chemicals;
	public int bienenstockUebrig;

	public Text chemicalsText;
	public Text bienenstockText;

	void Start()
	{
		
	}	

	void Update()
	{
		chemicalsText.text = ("Chemicals: " + chemicals);
		bienenstockText.text = ("Bienenstöcke übrig: " + bienenstockUebrig);
	}

}
