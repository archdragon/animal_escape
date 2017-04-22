using UnityEngine;
using System.Collections;

public class AnimalController : MonoBehaviour {
	private AnimalHealth animalHealth;
	private Animator animalAnimator;

	// Use this for initialization
	void Start () {
		animalHealth = gameObject.GetComponent<AnimalHealth> ();
		animalAnimator = GameObject.Find("Animal/Sheep").GetComponent<Animator> ();
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
		return (z < 0.0f || z > 4.0f || x > 5.0f || x < -50.0f);
	}

	void Move (float x, float z) {
		float targetX = transform.position.x + x;
		float targetZ = transform.position.z + z;
		GameObject obstacle = FindObstacleAt(targetX, targetZ);
		if(IsOutOfBounds(targetX, targetZ)) {
		} else if(obstacle != null) {
			animalHealth.ReactToCollision(obstacle);
		} else {
			Vector3 vector = new Vector3(x, 0.0f, z);
			transform.Translate(vector);
			animalAnimator.SetBool("Moving", true);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp("w") || Input.GetKeyUp(KeyCode.UpArrow)) {
			Move(-1.0f, 0.0f);
		} else if(Input.GetKeyUp("s") || Input.GetKeyUp(KeyCode.DownArrow)) {
			Move(1.0f, 0.0f);
		} else if(Input.GetKeyUp("d") || Input.GetKeyUp(KeyCode.RightArrow)) {
			Move(0.0f, 1.0f);
		} else if(Input.GetKeyUp("a") || Input.GetKeyUp(KeyCode.LeftArrow)) {
			Move(0.0f, -1.0f);
		}
	}

	public void Reset() {
		transform.position = new Vector3(0f, -180.588f, 2f);
	}
}
