using UnityEngine;
using System.Collections;

namespace Acrocatic {
	// Singleton class for the GameSettings.
	public class GameSettings : MonoBehaviour {
		private SpriteRenderer invisible_wall;
		// Public variables
		[Tooltip("Enable or disable the sprites for the colliders.")]
		public bool showColliders = false;

		// Static singleton property
		public static GameSettings Instance { get; private set; }
		
		void Awake() {
			// Save a reference to the GameSettings component as our singleton instance
			Instance = this;
		}
		void Start() {
			invisible_wall = GetComponent<SpriteRenderer>();
			invisible_wall.enabled = false;
		}
	}
}