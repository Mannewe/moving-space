using UnityEngine;
using System.Collections;

public class Moving2 : MonoBehaviour {

	public float speed;
	public float turnSpeed;
	public float projectileSpeed;
	public float boost = 10;
	float currentSpeed;
	float horizontal;
	float vertical;
	public Rigidbody2D projectile;
	Rigidbody2D bullet;

	void Start()
	{

	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
			Shoot ();
		}

		if (Input.GetKey (KeyCode.LeftShift) && boost > 0) {
			print (boost);
			boost -= Time.deltaTime;
			speed = 80;
		}
		else
			speed = 40;
	}

	void FixedUpdate()
	{
		horizontal = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");

		transform.Rotate (0,0,-horizontal * turnSpeed);
		GetComponent<Rigidbody2D> ().AddForce (gameObject.transform.up * speed * vertical);
	}

	void Shoot()
	{
		bullet = (Rigidbody2D) Instantiate (projectile, transform.position, transform.rotation);
		bullet.velocity = transform.up * (projectileSpeed + currentSpeed);
	}
}
