using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	bool leftShip = false;
	float inpact = 10;

	float enemyLives;

	public BoxCollider2D playerCollider;
	// Use this for initialization
	void Awake () 
	{
		Invoke ("DestroySelf", 2f);
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			other.gameObject.GetComponent<Rigidbody2D> ().AddForce (transform.up * inpact);
			other.gameObject.GetComponent<Enemy> ().LooseLife();
			DestroySelf ();
		}
	}

	void DestroySelf()
	{
		Destroy (gameObject);
	}
}
