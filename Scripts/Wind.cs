using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

	public float speed;
	public float destroyTime = 10f;

	private float timer;
	private float Rx;
	private float Ry;
	private Vector3 Path;
	private Vector3 PathR;

	void Start(){
		Rx = Random.Range (-0.2f, 0.2f);
		Ry = Random.Range (-0.1f, 0.1f);
		Path = new Vector3 (Rx, Ry, 1);
		PathR = new Vector3 (Rx,  0, 1350);
	}

	void Update () {

		// Move
		transform.Translate ( Path * Time.deltaTime * speed);
		transform.Rotate( PathR * Time.deltaTime);

		// self-Destroy
		timer += Time.deltaTime;
		if (timer >= destroyTime) {
			Destroy (gameObject);
		}
	}

	void OnTriggerExit(Collider col) {

		// Hit Pm
		if (col.tag == "PM") {	

			// Score_Skill
			if(Master.score < 500){
				Destroy (gameObject);
			}

			Destroy (col.gameObject);
			Master.score += 2;	
		}

		// Hit Enemy
		if (col.tag == "Enemy") {
			Destroy (gameObject);
		}
	}
}
