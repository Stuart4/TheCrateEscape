using UnityEngine;
using System.Collections;
using System;

public class Character : MonoBehaviour {
	public static bool camo = false;
	public float speed = 1f;
	public float upSpeed = 100f;
	public bool isGrounded = false;
	public bool canJump = true;
	public bool canHitTransmit = true;
	public bool canHitSwitch = true;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float torque = 5f;
	public float jumpDelay = 1f;
	public float buttonDelay = 0.4f;
	public bool transmitting = false;
	public int boxStatus = 0;
	private Rigidbody2D rb;
	private Animator animator;
	private Animator antennaAnim;
	private AudioSource jumpAudio;
	private AudioSource switchAudio;
	private AudioSource extendAudio;
	private AudioSource retractAudio;
	private AudioSource prepareAudio;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		AudioSource[] sources = GetComponents<AudioSource>();
		jumpAudio = sources[0];
		switchAudio = sources[1];
		extendAudio = sources[2];
		retractAudio = sources[3];
		foreach (Animator component in GetComponentsInChildren<Animator>()) {
			if (component.name == "antenna_0") {
				antennaAnim = component;
			} else if (component.name == "crate") {
				animator = component;
			}
		}
	}
	
	void Update () {
		Collider2D ground = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		if (ground == null) {
			isGrounded = false;
			camo = false;
		} else {
			isGrounded = true;
			switch (ground.gameObject.tag) {
				case "Mixed":
					camo = boxStatus == 0 && !transmitting;
					break;
				case "Dark":
					camo = boxStatus == 1 && !transmitting;
					break;
				case "Light":
					camo = boxStatus == 2 && !transmitting;
					break;
			}
		}
		if (Input.GetButtonDown("SwitchCrate") && transmitting && canHitSwitch) {
			switchCrate();
			Invoke ("resetHitSwitch", buttonDelay);
		}
		if (Input.GetButtonUp("Transmit") && canHitTransmit) {
			toggleTransmit();
			Invoke ("resetHitTransmit", buttonDelay);
		}
	}

	void FixedUpdate() {
		if (!transmitting) return;
		float xComponent = Input.GetAxis("Horizontal") * speed;
		float yComponent = rb.velocity.y;
		Vector2 movementVector = new Vector2(xComponent, yComponent);
		rb.velocity = movementVector;
		if (Input.GetAxis("Jump") > 0) Jump();
	}

	public void Jump() {
		if (isGrounded && canJump && transmitting) {
			float xComponent = rb.velocity.x;
			float yComponent = upSpeed;
			canJump = false;
			Invoke("resetJump", jumpDelay);
			jumpAudio.Play();
			Vector2 movementVector = new Vector2(xComponent, yComponent);
			rb.velocity = movementVector;
		}
	}

	public void switchCrate() {
		if (!transmitting) return;
		boxStatus = (boxStatus + 1) % 3;
		animator.SetInteger("boxStatus", boxStatus);
		switchAudio.Play();
	}

	public void toggleTransmit() {
			transmitting = !transmitting;
			antennaAnim.SetBool("transmitting", transmitting);
			Vector2 movementVector = new Vector2(0, rb.velocity.y);
			rb.velocity = movementVector;
			if (transmitting) {
				extendAudio.Play();
			} else {
				retractAudio.Play();
			}
	}

	void resetJump() {
		canJump = true;
	}

	void resetHitTransmit() {
		canHitTransmit = true;
	}

	void resetHitSwitch() {
		canHitSwitch = true;
	}
}
