using UnityEngine;
using System.Collections;

public class AnimalController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	bool IsOutOfBounds(float x, float z) {
    return (z < 0.0f || z > 4.0f);
	}

	void Move (float x, float z) {
		float targetX = transform.position.x + x;
		float targetZ = transform.position.z + z;
		if(!IsOutOfBounds(targetX, targetZ)) {
			Vector3 vector = new Vector3(x, 0.0f, z);
			transform.Translate(vector);
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
}
