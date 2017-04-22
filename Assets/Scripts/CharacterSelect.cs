using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour {
	private GameState gameState;

	// Use this for initialization
	void Start () {
		gameState = GameObject.Find ("Game State").GetComponent<GameState> ();
		//gameObject.GetComponent<Canvas> ().enabled = false;

	}

	public void Select(string name) {
		gameState.RestartWithCharacter(name);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
