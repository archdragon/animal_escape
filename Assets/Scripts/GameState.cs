using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	string[] states = new string[3]{"PLAYING", "DEAD", "SELECTING_ANIMAL"};
	string currentState = "PLAYING";

	public bool TransitionTo(string newState) {
		if (currentState == "PLAYING" && newState == "SELECTING_ANIMAL") {
			
		}
		return true;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
