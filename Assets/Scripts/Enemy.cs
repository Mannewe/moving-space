using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	Rigidbody2D bullet;
	GameObject player;
	float input;
	float speed = 6;
	public float lives = 3;

	public Rigidbody2D projectile;
	public float projectileSpeed;



	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		InvokeRepeating ("ChangeDistance", 5, 5f);
		InvokeRepeating ("Shoot", 1,1f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(player != null){
		var playerPos = Camera.main.ScreenToWorldPoint (player.transform.position);
		Quaternion rot = Quaternion.LookRotation (player.transform.position - transform.position, Vector3.back);

		transform.rotation = rot;
		transform.eulerAngles = new Vector3 (0, 0,  transform.eulerAngles.z);
		GetComponent<Rigidbody2D> ().angularVelocity = 0;

		GetComponent<SpringJoint2D> ().connectedBody = player.GetComponent<Rigidbody2D> ();

			//Kill if no lives
			if (lives <= 0)
				Destroy (gameObject);
		}


	}

	void ChangeDistance()
	{
		GetComponent<SpringJoint2D> ().distance = Random.Range (2,20);
	}

	void Shoot()
	{
		bullet = (Rigidbody2D) Instantiate (projectile, transform.position, transform.rotation);
		bullet.velocity = transform.up * (projectileSpeed);
	}

	public void LooseLife()
	{
		lives--;
	}
}
