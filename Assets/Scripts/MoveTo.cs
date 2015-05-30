using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour {
	public Transform target;
	public float speed = 0.2f;
	public bool rotate = true;
	// Use this for initialization
	void Start () {
		if (rotate) {
			transform.LookAt(target.position);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
	}
}
