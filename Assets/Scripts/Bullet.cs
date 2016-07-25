using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	bool leftShip = false;
	public BoxCollider2D playerCollider;
	// Use this for initialization
	void Awake () 
	{
		Invoke ("DestroySelf", 2f);
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag != "Player") 
		{
			other.gameObject.SetActive (false);
			DestroySelf ();
		}
	}

	void DestroySelf()
	{
		Destroy (gameObject);
	}
}
