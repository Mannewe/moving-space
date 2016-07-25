using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	GameObject player;
	float input;
	float speed = 6;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		print (player.transform.position);
		var playerPos = Camera.main.ScreenToWorldPoint (player.transform.position);
		Quaternion rot = Quaternion.LookRotation (transform.position - player.transform.position, Vector3.forward);

		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0, - transform.eulerAngles.z);
		GetComponent<Rigidbody2D> ().angularVelocity = 0;

		input = Input.GetAxis ("Vertical");
		GetComponent<Rigidbody2D> ().AddForce (transform.up * speed * -1);

	}
}
