using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int numJoueur = 0;
	public float jumpForce = 250.0f;
	public float moveSpeed = 8.0f;
	Rigidbody _rb = null;
	Collider _c = null;


	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody> ();
		_c = GetComponent<Collider> ();
		GameObject[] allPlayer = GameObject.FindGameObjectsWithTag ("Player");
		foreach (GameObject p in allPlayer)
			if (p.GetComponent<Collider> () != null)
				Physics.IgnoreCollision (p.GetComponent<Collider> (), _c);
	}
	
	// Update is called once per frame
	void Update () {
		//JUMP
		if (Input.GetButtonDown ("Jump" + numJoueur))
			Jump ();
		//MOVE
		_rb.velocity = new Vector3(moveSpeed*Input.GetAxis("Horizontal" + numJoueur), _rb.velocity.y, _rb.velocity.z);

		//Determine le sens du personnage
		if (Input.GetAxis ("Horizontal" + numJoueur) < 0)
			transform.localScale = new Vector3 (-1.0f, transform.localScale.y, transform.localScale.z);
		else if (Input.GetAxis ("Horizontal" + numJoueur) > 0)
			transform.localScale = new Vector3 (1.0f, transform.localScale.y, transform.localScale.z);
	}

	void Jump(){
		_rb.AddForce (jumpForce*transform.up);
	}
}
