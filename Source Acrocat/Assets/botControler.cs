using UnityEngine;
using System.Collections;

public class botControler : MonoBehaviour {

	private GameObject objectif;
	private CircleCollider2D pince;
	private Animator animator;

	// Use this for initialization
	void Start () {
		objectif = GameObject.FindGameObjectWithTag ("banana");
		CircleCollider2D[] allCollider = GetComponents<CircleCollider2D> ();
		foreach (CircleCollider2D c in allCollider) {
			if (c.isTrigger)
				pince = c;
		}
		animator = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards (new Vector2(transform.position.x, transform.position.y), objectif.transform.position, 4.0f*Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "banana") {
			other.transform.parent = transform;
			pince.offset = new Vector2 (-2.25f, 5.48f);
			animator.SetBool ("haveBanana", true);
		}
		else if (other.tag == "Player")
			animator.SetTrigger ("playerDetected");
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "banana") {
			other.transform.RotateAround (other.transform.localPosition, Vector3.forward, Time.deltaTime);
		}
	}
}
