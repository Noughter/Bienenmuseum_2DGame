using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//Floats
	public float maxSpeed;
	public float speed;
	public float jumpPower;

	//Booleans
	public bool grounded;
	public bool inBienenstockCol;

	//References
	private Rigidbody2D rb2d;
	private Animator anim;
	private GameMaster gm;


	// Use this for initialization 
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();			//referneziert Objekte zu Unity Objekte
		anim = gameObject.GetComponent<Animator> ();

		gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
	}
	
	// Update is called once per frame
	void Update () 
	{


		anim.SetBool ("Grounded", grounded); 				//referenziert script grounded mit Unity Animator Grounded
		anim.SetFloat ("Speed",Mathf.Abs(rb2d.velocity.x));   //Math Abs lässt  nur Positiv zu und weist actual Speed zu


		if (Input.GetAxis ("Horizontal") < -0.1f) 			//flippt Animation je nach Richtung
		{
			transform.localScale = new Vector3 (-1, 1, 1);
		}

		if (Input.GetAxis ("Horizontal") > 0.1f) 			
		{
			transform.localScale = new Vector3 (1, 1, 1);
		}

		if (Input.GetButtonDown("Jump") && grounded) 			
		{
			rb2d.AddForce (Vector2.up * jumpPower);
		}



		if (Input.GetKeyDown(KeyCode.C) && inBienenstockCol && gm.chemicals >= 1) 
		{
			Debug.Log ("Du hast einen Bienenstock befreit");
			gm.bienenstockUebrig -= 1;
			gm.chemicals -= 1;
		}

	}

	void FixedUpdate() 
	{
		float h = Input.GetAxis ("Horizontal");					// Holt gedrückten Key ( wenn links gedrückt wird wird Wert negativ)		

		// Bewegt Spieler mit Keys
		rb2d.AddForce ((Vector2.right * speed) * h);

		//Limited Max Speed	
		if (rb2d.velocity.x > maxSpeed) {		
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}

		if (rb2d.velocity.x < -maxSpeed) {											
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Chemical")) 
		{
			Destroy(col.gameObject);
			gm.chemicals += 1;
		}
			
		if (col.CompareTag("Bienenstock")) 
		{
			inBienenstockCol = true;
		}
	}


}
