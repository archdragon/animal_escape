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

		controller.Reset();
		health.Reset();
		TransitionTo("PLAYING");
	}
}
