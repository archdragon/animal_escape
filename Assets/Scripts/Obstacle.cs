using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	public string obstacleType = "Rock";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Reveal() {
		MeshRenderer mesh = transform.Find ("Body").gameObject.GetComponent<MeshRenderer> ();
		if (mesh.enabled == false) {
			mesh.enabled = true;
			gameObject.GetComponent<ParticleSystem> ().Play ();
		}
	}

	public void Toggle(string animalName) {
		bool shouldDissapear = false;

		switch (animalName) {
			case "Pig":
				if (obstacleType == "Rock") {
					shouldDissapear = true;
				}
			break;
			case "Cow":
				if (obstacleType == "Fence") {
					shouldDissapear = true;
				}
			break;
			case "Sheep":
				if (obstacleType == "Grass") {
					shouldDissapear = true;
				}
			break;
		}

		MeshRenderer mesh = transform.Find ("Body").gameObject.GetComponent<MeshRenderer> ();

		mesh.enabled = !shouldDissapear;
	}
}
