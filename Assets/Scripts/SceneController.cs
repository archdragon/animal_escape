﻿using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToLevel(string name) {
		if (name == "exit") {
			Application.Quit ();
		} else {
			Application.LoadLevel (name);
		}
	}
}
