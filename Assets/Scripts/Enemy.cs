using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	GameManager gm;
	Rigidbody2D bullet;
	GameObject player;
	GameObject deathparticles;

	float input;
	float speed = 6;
	public float lives = 3;
	public GameObject deathParticle;

	public Rigidbody2D projectile;
	public float projectileSpeed;

	float randomDirection;

	bool strafe = true;



	// Use this for initialization
	void Start () {
		gm = GameObject.Find ("Main Camera").GetComponent<GameManager> ();
		player = GameObject.FindWithTag ("Player");
		InvokeRepeating ("ChangeDistance", 2, 2f);
		InvokeRepeating ("Shoot", 1,1f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(player != null){
			
			var mousePosition = Camera.main.ScreenToWorldPoint (player.transform.position);
			Quaternion rot = Quaternion.LookRotation (transform.forward, player.transform.position - transform.position);

			transform.rotation = rot;
			transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
			GetComponent<Rigidbody2D> ().angularVelocity = 0;

		GetComponent<SpringJoint2D> ().connectedBody = player.GetComponent<Rigidbody2D> ();

			//Kill if no lives
			if (lives <= 0) {
				gm.NrOfEnemies ();
				deathparticles = (GameObject)Instantiate (deathParticle, transform.position, Quaternion.identity);
				Destroy (gameObject);
			}

			if (strafe)
				GetComponent<Rigidbody2D> ().velocity = transform.right * randomDirection/2;
		}


	}

	void ChangeDistance()
	{
		randomDirection = Random.Range(-10,10);
		GetComponent<SpringJoint2D> ().distance = Random.Range (2,10);
		strafe = !strafe;
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
