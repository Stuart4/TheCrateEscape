using System;
using UnityEngine;
using System.Collections;

public class SpotlightRotator : MonoBehaviour {

	public Vector3andSpace rotateUnitsPerSecond;
	public LayerMask whatIsPlayer;
	public LayerMask whatIsGround;
	public float degreesGreater;
	public float degreesLesser;
	public Transform spotlightCheck;
	public float playerRadius;
	public float prefabRadius;
	public GameObject exclamation;
	public GameObject deathEffect;
	public GameObject character;
	public GameObject antenna;
	public GameObject bird;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(rotateUnitsPerSecond.value * Time.deltaTime, rotateUnitsPerSecond.space);
		//includes zero degrees
		if ((transform.rotation.eulerAngles.y > degreesGreater && transform.rotation.eulerAngles.y <= 0) || (transform.rotation.eulerAngles.y >= 0 && transform.rotation.eulerAngles.y < degreesLesser)) {
			if (!Character.camo) {
				playerFailed();
			}
		}
	}

	private void playerFailed() {
		exclamation.SetActive(true);
		antenna.SetActive(false);
		Invoke("killIt", 1);
	}

	private void killIt() {
		exclamation.SetActive(false);
		deathEffect.transform.position = character.transform.position + new Vector3(-2.45f, -4.55f, 0f);
		deathEffect.SetActive(true);
		bird.SetActive(true);
		character.SetActive(false);
		Invoke("endScene", .4f);
	}

	private void endScene() {

		Application.LoadLevel("failure");
	}

	[Serializable]
    public class Vector3andSpace {
    	public Vector3 value;
        public Space space = Space.Self;
    }
}
