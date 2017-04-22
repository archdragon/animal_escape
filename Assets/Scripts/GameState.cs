using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	string[] states = new string[3]{"PLAYING", "DEAD", "SELECTING_ANIMAL"};
	string currentState = "PLAYING";

	GameObject selectScreen;
	GameObject player;

	public bool TransitionTo(string newState) {

		switch (newState) {
			case "PLAYING":
				HideSelectScreen ();
			break;
			case "DEAD":
				if (currentState == "PLAYING") {
					currentState = "DEAD";
				}
				TransitionTo ("SELECTING_ANIMAL");
			break;
			case "SELECTING_ANIMAL":
				ShowSelectScreen ();
			break;
		}

		currentState = newState;
		return true;
	}

	void ShowSelectScreen() {
		selectScreen.SetActive (true);
	}

	void HideSelectScreen() {
		selectScreen.SetActive (false);
	}

	// Use this for initialization
	void Start () {
		selectScreen = GameObject.Find ("Canvas - Select Character");
		player = GameObject.Find("Player");
		TransitionTo("PLAYING");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RestartWithCharacter(string name) {
		AnimalController controller = player.GetComponent<AnimalController> ();
		AnimalHealth health = player.GetComponent<AnimalHealth> ();

		ChooseAnimalModel(name);

		controller.Reset();
		health.Reset();
		TransitionTo("PLAYING");
	}

	void ChooseAnimalModel(string name) {
		GameObject.Find ("Animal").transform.GetChild (0).SetParent(
			GameObject.Find("Animals").transform
		);
		GameObject newAnimal = GameObject.Find ("Animals").transform.Find(name).gameObject;
		newAnimal.transform.SetParent(
			GameObject.Find("Animal").transform
		);
		newAnimal.transform.localPosition = new Vector3(0f, -0.3f, 0f);

		HideUnusedModels();
		ShowUsedModels();
	}

	void HideUnusedModels() {
		Transform animals = GameObject.Find ("Animals").transform;
		foreach (Transform animal in animals) {
			animal.gameObject.SetActive(false);
		}

	}

	void ShowUsedModels() {
		Transform animals = GameObject.Find ("Animal").transform;
		foreach (Transform animal in animals) {
			animal.gameObject.SetActive(true);
		}
	}
}
