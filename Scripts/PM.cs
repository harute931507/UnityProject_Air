using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM : MonoBehaviour {

	public float PM_speed;
	public float destroyTime = 8;

	private float timer;
	private float Rx;
	private Vector3 Path;

	void Start(){
		Rx = Random.Range (-0.05f, 0.05f);
		Path = new Vector3 (Rx, 0, 1);
	}

	void Update () {

		// Move
		transform.Translate ( Path * Time.deltaTime * PM_speed);

		// self-Destroy
		timer += Time.deltaTime;
		if (timer > destroyTime) {
			Destroy (gameObject);
		}
	}
	void OnTriggerExit(Collider col) {
		if (col.tag == "Skill") {
			Destroy (gameObject);
		}
	}
}
