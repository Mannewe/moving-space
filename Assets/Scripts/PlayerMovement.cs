using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Animator anim;
	float input;
	public float speed;
	public float turnSpeed;
	public float projectileSpeed;
	public float boost = 10;
	float currentSpeed;
	float horizontal;
	float vertical;
	public Vector3 currentPos;
	public Rigidbody2D projectile;
	Rigidbody2D bullet;


	void Awake()
	{
		anim = gameObject.GetComponent<Animator> ();	
	}

	void Update()
	{	
		currentPos = transform.position;
		print (currentPos);

		if(input > 0 || input < 0){
			anim.SetFloat("speed", input);
		}
			
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
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);

		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		GetComponent<Rigidbody2D> ().angularVelocity = 0;

		input = Input.GetAxis ("Vertical");
		GetComponent<Rigidbody2D> ().AddForce (transform.up * speed * input);
	}

	void Shoot()
	{
		bullet = (Rigidbody2D) Instantiate (projectile, transform.position, transform.rotation);
		if(input <= 0.2 && input >= - 0.2)
		bullet.velocity = transform.up * (projectileSpeed);
		else if(input > 0.2 && !Input.GetKey(KeyCode.LeftShift) || input < - 0.2 && !Input.GetKey(KeyCode.LeftShift))
			bullet.velocity = transform.up * (projectileSpeed + 7);
		else if(Input.GetKey(KeyCode.LeftShift))
			bullet.velocity = transform.up * (projectileSpeed + 17);
	}
}
