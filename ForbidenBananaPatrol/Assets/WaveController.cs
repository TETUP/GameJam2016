using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {

	public GameObject simpleBot = null;
	private Transform[] spawn1 = null;

	public int nbwave = 10;
	public float interval = 3.0f;
	public float chances = 50.0f;
	static private bool changewave = false;
	private int currentwave = 1;
	private float spawntime = 0.0f;
	private int currentspawn = 0;
	private int nbspawn = 5;
	private float wavetime = 0.0f;
	private float respawnwavetime = 5.0f;

	public static int nbdeath = 0;

	// Use this for initialization
	void Start () {
		GameObject[] allExit = GameObject.FindGameObjectsWithTag ("lvl1");
		spawn1 = new Transform[allExit.Length];
		int i = 0;
		foreach (GameObject exit in allExit) {
			spawn1 [i] = exit.transform;
			i++;
		}
	}

	// Update is called once per frame
	void Update () {
		if (currentwave <= nbwave ){
			if (Time.time - wavetime > respawnwavetime) {
				if (currentspawn <= nbspawn && !changewave) {
					if (Time.time - spawntime > interval) {
						Debug.Log ("let the wave begin");
						if (Random.Range (0.0f, 100.0f) < chances)
							Instantiate (simpleBot, spawn1 [0].position, spawn1 [0].rotation);
						else
							Instantiate (simpleBot, spawn1 [1].position, spawn1 [1].rotation);
						spawntime = Time.time;
						currentspawn++;
					} 
				}
				//une fois par wave 
				else {
					currentwave++;
					changewave = false;
					wavetime = Time.time;
				}
			}
		}

	}

	public static void addDead(){
		nbdeath++;
		if (nbdeath > 4)
			changewave = true;
	}
}
