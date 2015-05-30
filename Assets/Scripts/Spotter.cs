using UnityEngine;
using System.Collections;

public class Spotter : MonoBehaviour {

	void Update() {
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log("Collision");
	}
}
