using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag  == "Player") {
			Application.LoadLevel("failure");
			return;
		}
		if (collider.gameObject.transform.parent) {
			collider.gameObject.transform.parent.gameObject.SetActive(false);
		} else {
			collider.gameObject.SetActive(false);
		}
	}

} 