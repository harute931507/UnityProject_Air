using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Ball : MonoBehaviour {

	public float Speed;
	public float Destroy_Time;

	private float Rx;
	private float Ry;
	private float Rz;
	private float Timer;
	private GameObject Player;




	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		Timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		Timer += Time.deltaTime;
		if (Timer >= Destroy_Time) {
			Destroy (gameObject);
		}

		Rx = Time.deltaTime * Speed;
		Ry = Time.deltaTime * Speed/2;
		Rz = Time.deltaTime * Speed/3;

		//transform.LookAt (Player.transform);
		transform.Rotate (Rx,Ry,Rz);
		transform.RotateAround (Player.transform.position, Vector3.up, 900 * Time.deltaTime);
	}
}
