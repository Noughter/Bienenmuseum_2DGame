using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

	private Player player; //referenzt Player Script

	// Use this for initialization
	void Start () 
	{
		player = gameObject.GetComponentInParent<Player>();
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		player.grounded = true;
	}

	void OnTriggerStay2D(Collider2D col)	//Bugfix macht sicher das auch grounded bleibt
	{
		player.grounded = true;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		player.grounded = false;
	}
}
