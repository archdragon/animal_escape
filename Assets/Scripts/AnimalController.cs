using UnityEngine;
using System.Collections;

public class AnimalController : MonoBehaviour {
	private AnimalHealth animalHealth;
	private Animator animalAnimator;
	private bool isMoving = false;
	private Vector3 moveTarget;
	private float movementTargetX;
	private float movementTargetZ;
	private SceneController sceneController;
	public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		animalHealth = gameObject.GetComponent<AnimalHealth> ();
		sceneController = GameObject.Find ("Scene Controller").GetComponent<SceneController> ();
		Reset();
	}

	void ConnectAnimator() {
		animalAnimator = GameObject.Find("Animal").transform.GetChild(0).gameObject.GetComponent<Animator> ();
	}

	GameObject FindObstacleAt(float x, float z) {
		int gridX = Mathf.RoundToInt(x);
		int gridZ = Mathf.RoundToInt(z);
		GameObject[] obstacles;
		obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

		foreach (GameObject obstacle in obstacles) {
			//Debug.Log((int)obstacle.transform.position.x + " " + gridX + " " + (int)obstacle.transform.position.y + " " + gridY);
			if(Mathf.RoundToInt(obstacle.transform.position.x) == gridX && Mathf.RoundToInt(obstacle.transform.position.z) == gridZ) {
				Debug.Log("Found Obstacle");
				return obstacle;
			}
		}
		return null;
	}

	bool IsOutOfBounds(float x, float z) {
		return (Mathf.Round(z) < 0.0f || Mathf.Round(z) > 4.0f || Mathf.Round(x) > 5.0f);
	}

	bool IsFinishReached(float x, float z) {
		return (x < -27.0f);
	}

	void Move (float x, float z) {
		float targetX = transform.position.x + x;
		float targetZ = transform.position.z + z;
		GameObject obstacle = FindObstacleAt(targetX, targetZ);
		if (IsFinishReached (targetX, targetZ)) {
			sceneController.GoToLevel ("victory_screen");
		} else if(IsOutOfBounds(targetX, targetZ)) {
			Debug.Log("Out of bounds");
		} else if(obstacle != null) {
			obstacle.gameObject.GetComponent<Obstacle>().Reveal();
			GetComponent<ParticleSystem> ().Play ();
			animalHealth.ReactToCollision(obstacle);
			PlaySound ("Bump");
		} else {
			PlaySound ("Move");
			Vector3 vector = new Vector3(x, 0.0f, z);
			//transform.Translate(vector);
			StartMoving(targetX, targetZ);
		}
	}

	void StartMoving(float targetX, float targetZ) {
		movementTargetX = targetX;
		movementTargetZ = targetZ;
		isMoving = true;
		animalAnimator.SetBool("Moving", true);
	}

	void StopMoving() { 
		isMoving = false;
		animalAnimator.SetBool("Moving", false);
	}

	// Update is called once per frame
	void Update () {
		if (isMoving) {

			float alteredSpeed = speed;

			if (movementTargetZ != 0.0f) {
				alteredSpeed = speed * 2.0f;
			}

			float step = alteredSpeed * Time.deltaTime;
			Vector3 targetVector = new Vector3 (movementTargetX, transform.position.y, movementTargetZ);
			transform.position = Vector3.MoveTowards(transform.position, targetVector, step);

			if (Vector3.Distance (transform.position, targetVector) < 0.05) {
				StopMoving();
			}
		} else {
			if (Input.GetKeyUp ("w") || Input.GetKeyUp (KeyCode.UpArrow)) {
				Move (-1.0f, 0.0f);
			} else if (Input.GetKeyUp ("s") || Input.GetKeyUp (KeyCode.DownArrow)) {
				Move (1.0f, 0.0f);
			} else if (Input.GetKeyUp ("d") || Input.GetKeyUp (KeyCode.RightArrow)) {
				Move (0.0f, 1.0f);
			} else if (Input.GetKeyUp ("a") || Input.GetKeyUp (KeyCode.LeftArrow)) {
				Move (0.0f, -1.0f);
			}
		} 
	}

	public void Reset() {
		ConnectAnimator();
		transform.position = new Vector3(0f, -180.588f, 2f);
	}

	public void PlaySound(string name) {
		transform.Find ("Sounds/" + name).gameObject.GetComponent<AudioSource> ().Play ();
	}


}
