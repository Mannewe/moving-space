using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public int level;
	public Rigidbody2D player;
	public GameObject enemy;
	Rigidbody2D playerInstance;
	GameObject enemyInstance;
	// Use this for initialization
	void Awake () {
		playerInstance = (Rigidbody2D) Instantiate (player, new Vector3(0,0,0), Quaternion.identity);
		GetComponent<SpringJoint2D> ().connectedBody = playerInstance;

		for(int i = 0; i < level; i++)
			enemyInstance = (GameObject) Instantiate (enemy, RandomSpawn() , transform.rotation);
	}

	Vector3 RandomSpawn()
	{
		float xPos = Random.Range (-5,5);
		float yPos = Random.Range (-5,5);

		Vector3 randomSpawn = new Vector3 (xPos, yPos, 0);
		return randomSpawn;
	}
}
