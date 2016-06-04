using UnityEngine;
using System.Collections;

public class BasicBot : MonoBehaviour {

	GameObject objectif = null;
	Rigidbody _rb = null;

	// Use this for initialization
	void Start () {
		objectif = GameObject.FindGameObjectWithTag ("Banana");
		_rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (objectif != null)
			_rb.velocity = Vector3.Normalize(objectif.transform.position-transform.position);
		
		//Determine le sens du personnage
		if (_rb.velocity.x < 0)
			transform.localScale = new Vector3 (-1.0f, transform.localScale.y, transform.localScale.z);
		else if (_rb.velocity.x > 0)
			transform.localScale = new Vector3 (1.0f, transform.localScale.y, transform.localScale.z);
	}

	public void ChangeObjectif(){
		//Observe les sortie possible
		GameObject[] allexit = GameObject.FindGameObjectsWithTag ("Exit");
		GameObject selectExit = null;
		//Choisi la sortie parmi toute
		foreach (GameObject exit in allexit) {

			if (selectExit == null) {
				selectExit = exit;
			}
			if (Vector3.Distance (exit.transform.position, transform.position) < Vector3.Distance (selectExit.transform.position, transform.position)) {
				selectExit = exit;
			}
		}
		//Change l'objectif du bot
		objectif = selectExit;
	}
}
