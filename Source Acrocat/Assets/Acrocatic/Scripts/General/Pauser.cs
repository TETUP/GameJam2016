using UnityEngine;
//using UnityEngine.Sprites;
using System.Collections;

public class Pauser : MonoBehaviour {
	private bool paused = false;
	private SpriteRenderer pause;
	private SpriteRenderer fond;

	void Start () {
		pause = GetComponent<SpriteRenderer> ();
		fond = fond.GetComponent("Fond pause") as SpriteRenderer;
		//pause.enabled = false;
	}

	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetButtonDown("Pause"))
		{
			paused = !paused;
		}

		if (paused) {
			pause.enabled = true;
			fond.enabled = true;
			Time.timeScale = 0;
		}
			
		else
			pause.enabled = false;
			fond.enabled = false;
			Time.timeScale = 1;
	}
}
