using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	Animator anim;

	float input;
	float currentSpeed;

	float horizontal;
	float vertical;

	bool shooting = true;

	Rigidbody2D[] bullet;
	Text livesText;

	public bool shooter = false;
	public float speed;
	public float turnSpeed;
	public float projectileSpeed;
	public float boost = 10;
	public float fireRate;
	public float lives = 5;

	public Vector3 currentPos;

	public Rigidbody2D projectile1;



	void Awake()
	{
		bullet = new Rigidbody2D[3];
		anim = gameObject.GetComponent<Animator> ();
		livesText = GameObject.Find ("Text").GetComponent<Text>();
	}

	void Start(){
	}

	void Update()
	{	
		print (shooting);
		currentPos = transform.position;

		if(input > 0 || input < 0){
			anim.SetFloat("speed", input);
		}
			
		if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space)) {
			Shoot ();
		}

		if (Input.GetKey (KeyCode.LeftShift) && boost > 0) {
			boost -= Time.deltaTime;
			speed = 80;
		}
		else
			speed = 40;

		if (lives <= 0) {
			Destroy (gameObject);
			livesText.text = "DEAD";
		} else
			livesText.text = "" + lives;
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
		if (shooting == true) {
			Weapon1 ();
		}
	}

	public void LooseLife()
	{
		lives--;
	}

	void AbleToShoot()
	{
		shooting = true;
	}


	void Weapon1()
	{
		bullet[0] = (Rigidbody2D)Instantiate (projectile1, transform.position, transform.rotation);
		if (input <= 0.2 && input >= -0.2)
			bullet[0].velocity = transform.up * (projectileSpeed);
		else if (input > 0.2 && !Input.GetKey (KeyCode.LeftShift) || input < -0.2 && !Input.GetKey (KeyCode.LeftShift))
			bullet[0].velocity = transform.up * (projectileSpeed + 7);
		else if (Input.GetKey (KeyCode.LeftShift))
			bullet[0].velocity = transform.up * (projectileSpeed + 17);
		Invoke ("AbleToShoot",fireRate);
		shooting = false;
	}

	void Weapon2()
	{

		bullet[0] = (Rigidbody2D)Instantiate (projectile1, transform.position, transform.rotation);
		bullet [1] = (Rigidbody2D)Instantiate (projectile1, transform.position, transform.rotation);
		bullet[2] = (Rigidbody2D)Instantiate (projectile1, transform.position, transform.rotation);

		bullet [0].transform.Rotate (0,0,10);
		bullet [1].transform.Rotate (0, 0, -10);

		if (input <= 0.2 && input >= -0.2)
			for (int i = 0; i < bullet.Length; i++) {
				bullet [i].velocity = bullet[i].transform.up * (projectileSpeed);
			}
		else if (input > 0.2 && !Input.GetKey (KeyCode.LeftShift) || input < -0.2 && !Input.GetKey (KeyCode.LeftShift))
			for (int i = 0; i < bullet.Length; i++) {
				bullet [i].velocity = bullet[i].transform.up * (projectileSpeed + 7);
			}
		else if (Input.GetKey (KeyCode.LeftShift))
			for (int i = 0; i < bullet.Length; i++) {
				bullet[i].velocity = bullet[i].transform.up * (projectileSpeed + 17);
			}
		Invoke ("AbleToShoot",fireRate);
		shooting = false;
	}
}
