using UnityEngine;
using System.Collections;

public class AnimalHealth : MonoBehaviour {
	public int healthLevel = 3;
	// Use this for initialization
	void Start () {
	}

	public void ReactToCollision(GameObject obstacle) {
		string collisionType = "test";
		switch (collisionType) {
		  case "hole":
			healthLevel = 0;
		  break;
		  default:
			healthLevel--;
		  break;
		}

	}
		
	
	// Update is called once per frame
	void Update () {
	
	}
}
