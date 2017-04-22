using UnityEngine;
using System.Collections;

public class AnimalHealth : MonoBehaviour {
	public int healthLevel = 3;
	private GameState gameState;
	// Use this for initialization
	void Start () {
		gameState = GameObject.Find ("Game State").GetComponent<GameState> ();
	}

	void SubstractHealth(int amount) {
		healthLevel -= amount;
		if (healthLevel <= 0) {
			gameState.TransitionTo ("DEAD");
		}
	}

	public void Reset() {
		healthLevel = 3;
	}

	public void ReactToCollision(GameObject obstacle) {
		string collisionType = "test";
		switch (collisionType) {
		  case "hole":
			SubstractHealth(healthLevel);
		  break;
		  default:
			SubstractHealth(1);
		  break;
		}

	}
		
	
	// Update is called once per frame
	void Update () {
	
	}
}
