using UnityEngine;
using System.Collections;

public class TouchBanana : MonoBehaviour {

	GameObject banana = null;
	private bool haveBanana = false;
	BasicBot _botscript = null;

	// Use this for initialization
	void Start () {
		_botscript = transform.parent.GetComponent<BasicBot> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider c){
		if (c.gameObject.tag == "Banana") {
			banana = c.gameObject; 
			c.transform.parent = this.transform;
			haveBanana = true;
			transform.localPosition = new Vector3 (0.64f, 1.14f, 0.0f);
			_botscript.ChangeObjectif ();
		}

	}

	void OnDestroy(){
		if (haveBanana)
			banana.transform.parent = null;
	}
}
