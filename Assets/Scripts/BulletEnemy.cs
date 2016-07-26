using UnityEngine;
using System.Collections;

public class BulletEnemy : MonoBehaviour {

	public BoxCollider2D enemyCollider;
	float inpact = 1000;
	// Use this for initialization
	void Awake () 
	{
		Invoke ("DestroySelf", 8f);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			other.gameObject.GetComponent<Rigidbody2D> ().AddForce (transform.up * inpact * 1);
			other.GetComponent<PlayerMovement> ().LooseLife ();
			DestroySelf ();
		}
	}

	void DestroySelf()
	{
		Destroy (gameObject);
	}
}

