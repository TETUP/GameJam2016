using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {

	public GameObject player = null;
	private bool check1 = false;
	private bool check2 = false;
	private bool check3 = false;
	private bool check4 = false;
	// Use this for initialization
	void Start () {
		if (player == null)
			Debug.Log ("Remplir la case Player avec un GameObject");
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Jump1") && !check1) {
			GameObject p1 = (GameObject)Instantiate (player, Vector3.zero, transform.rotation);
			if (p1.GetComponent<Acrocatic.Player> () != null)
				p1.GetComponent<Acrocatic.Player> ().numJoueur = 1;
			check1 = true;
		}
		else if (Input.GetButton("Jump2") && !check2){
			GameObject p2 = (GameObject)Instantiate (player, Vector3.zero, transform.rotation);
			//if (p2.GetComponent<PlayerController> () != null)
			//	p2.GetComponent<PlayerController> ().numJoueur = 2;
			check2 = true;
		}

		else if (Input.GetButton("Jump3") && !check3){
			GameObject p3 = (GameObject)Instantiate (player, Vector3.zero, transform.rotation);
			//if (p3.GetComponent<PlayerController> () != null)
			//	p3.GetComponent<PlayerController> ().numJoueur = 3;
			check3 = true;
		}

		else if (Input.GetButton("Jump4") && !check4){
			GameObject p4 = (GameObject)Instantiate (player, Vector3.zero, transform.rotation);
			//if (p4.GetComponent<PlayerController> () != null)
			//	p4.GetComponent<PlayerController> ().numJoueur = 4;
			check4 = true;
		}
	}
}
