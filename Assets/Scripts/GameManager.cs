using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public int nrOfEnemies;
	public int level;
	public Rigidbody2D player;
	public GameObject enemy;
	Rigidbody2D playerInstance;
	GameObject enemyInstance;

	Text nrOfEnemiesText;

//	PlayerMovement playerScript;
//	PlayerMovement enemyScript;

	// Use this for initialization
	void Awake () {
		playerInstance = (Rigidbody2D) Instantiate (player, new Vector3(0,0,0), Quaternion.identity);
		GetComponent<SpringJoint2D> ().connectedBody = playerInstance;
		
		nrOfEnemiesText = GameObject.Find ("Text2").GetComponent<Text>();
		nrOfEnemies = level;
		for (int i = 0; i < level; i++) {
			enemyInstance = (GameObject) Instantiate (enemy, RandomSpawn (), transform.rotation);
		}
	}

	void Update()
	{
		nrOfEnemiesText.text = "Enemies left : " + nrOfEnemies;
	}

	Vector3 RandomSpawn()
	{
		float xPos = Random.Range (-5,5);
		float yPos = Random.Range (-5,5);

		Vector3 randomSpawn = new Vector3 (xPos, yPos, 0);
		return randomSpawn;
	}
		
	public void NrOfEnemies()
	{
		nrOfEnemies--;
	}
}
