using UnityEngine;
using System.Collections;

public class DeathParticle : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		Invoke ("DestroySelf" , 2f);
	}
	
	void DestroySelf()
	{
		Destroy (gameObject);
	}
}
