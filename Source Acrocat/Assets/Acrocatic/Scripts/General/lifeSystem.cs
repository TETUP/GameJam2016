using UnityEngine;
using System.Collections;

public class lifeSystem : MonoBehaviour {

	public float dgt = 8.0f;
	public float life = 115.0f;
	private int numJoueur = 0;

	// Use this for initialization
	void Start () {
		if (GetComponent<Acrocatic.Player> () != null)
			numJoueur = GetComponent<Acrocatic.Player> ().numJoueur;
	}

	void OnTriggerEnter2D (Collider2D c){
		
		if (tag == "Player") {
			if (Input.GetButtonDown ("Attack" + numJoueur)) {
				c.GetComponent<lifeSystem> ().ApplyDamage (dgt);
				if (Input.GetButtonDown ("Attack" + numJoueur))
					c.attachedRigidbody.AddForce (100.0f * (transform.right + transform.up));
			}
		} else if (tag == "bot") {
			if (c.tag == "player") {
				c.GetComponent<lifeSystem> ().ApplyDamage (dgt);
			}
		}
	}

	public void ApplyDamage(float dgt){
		life -= dgt;
	}
}
