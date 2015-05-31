using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {
	public float timeUntilDeath = 5f;
	// Use this for initialization
	void Start () {
		Invoke("kill", timeUntilDeath);
	}
	
	void kill () {
		Destroy(gameObject);
	}
}
