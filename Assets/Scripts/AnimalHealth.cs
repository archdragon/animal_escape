using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimalHealth : MonoBehaviour {
	public int healthLevel = 3;
	private GameState gameState;
	public GameObject hearts;
	public Sprite[] heartSprites; 
	// Use this for initialization
	void Start () {
		gameState = GameObject.Find ("Game State").GetComponent<GameState> ();
	}

	void SubstractHealth(int amount) {
		healthLevel -= amount;
		RefreshUI();
		if (healthLevel <= 0) {
			StartCoroutine(DieAfterTime(0.5f));
		}
	}

	public void Reset() {
		healthLevel = 3;
		RefreshUI();
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

	void RefreshUI() {
		int heartId = Mathf.Clamp(healthLevel, 0, 3);

		hearts.GetComponent<Image>().sprite = heartSprites[heartId];
	}

	IEnumerator DieAfterTime(float time)
	{
		yield return new WaitForSeconds(time);

		// Code to execute after the delay
		gameState.TransitionTo ("DEAD");
	}
		
}
