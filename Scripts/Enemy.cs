using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	// Enemy's number
	public static int number = 0;

	public float Speed = 80;
	public float Frequence = 1;
	public int Health;
	public bool Trinity = false;
	public GameObject PM;
	public Transform ShootPosM;
	public Transform ShootPosL;
	public Transform ShootPosR;

	private float PM_Timer;
	private float Move_Timer;
	private float RealSpeed;
	private float BackwardSpeed;
	private float Step;
	private float NTD = 1f;
	private GameObject Player;
	private CharacterController Controller;
	private Light MyLight;
	private Vector3 P;
	private Vector3 M;
	private Vector3 P_M;
	private float anti_Skill;


	// HP
	private int MAX_HEALTH = 3;
	public Image HpBar;

	void Start () {

		Controller = GetComponent<CharacterController>();
		MyLight = GetComponent<Light> ();

		// Hard Mode
		if(Master.score >= 300){
			if (Random.Range (0, Master.score) > 300) {
				Trinity = true;
				MAX_HEALTH = 10;
				gameObject.GetComponent<MeshRenderer> ().material.color = new Color32(0xCC,0x94,0x00,0xFF);
			}
			if (Random.Range (0, Master.score) > 300) {
				MyLight.enabled = !MyLight.enabled;
				MAX_HEALTH = 10;
				gameObject.GetComponent<MeshRenderer> ().material.color = new Color32(0x90,0x00,0x00,0xFF);
				MyLight.color = new Color32 (0x90, 0x00, 0x00, 0xFF);
			}
			if (MyLight.enabled && Trinity) {
				MAX_HEALTH = 15;
				MyLight.intensity = 15;
				NTD = 3f; 
				gameObject.GetComponent<MeshRenderer> ().material.color = new Color32(0xA0,0x00,0xBA,0xFF);
				MyLight.color = new Color32(0xA0,0x00,0xBA,0xFF);
			}
		}

		if (Master.score >= 1000) {
			Frequence += Master.score / 10000f;
		}

		// Initial
		PM_Timer = 0f;
		Move_Timer = 0f;
		Speed = Speed * NTD;
		RealSpeed = Speed ;
		BackwardSpeed = -150f * NTD;
		Step = 1f;
		Health = MAX_HEALTH;

		// Find Player
		Player = GameObject.Find ("Player");
	}
	void Update () {
		// Check Life
		if (Health <= 0) {
			Master.score += 50;		
			Destroy (gameObject);	
		}


		// Timer
		Move_Timer += Time.deltaTime;
		PM_Timer -= Time.deltaTime;
		anti_Skill -= Time.deltaTime; 
		// Get Position
		P = Player.transform.position;
		M = transform.position;
		P_M = new Vector3((P.x-M.x), 0, (P.z-M.z));

		// Look at Player
		transform.LookAt (Player.transform);

		// Keep Moving
		//Controller.SimpleMove ( P_M.normalized * Time.deltaTime * RealSpeed * Step);

		// Check Distance
		if (P_M.magnitude <= 8 ) {
			Step = 1f;
			RealSpeed = BackwardSpeed;
			Move_Timer = 0;
		} else if (P_M.magnitude > 10) {
			Step = 1f;
			if (Move_Timer > 1) {
				RealSpeed = Speed;
			}

		} else {
			if (Move_Timer > 1) {
				Step = 0f;
			}
		}
			
		// Fire Frequence
		if (PM_Timer <= 1) {
			Instantiate (PM, ShootPosM.position, ShootPosM.rotation);
			if(Trinity){
				Instantiate (PM, ShootPosL.position, ShootPosL.rotation);
				Instantiate (PM, ShootPosR.position, ShootPosR.rotation);
			}
			PM_Timer = 1+(1/Frequence);
		}
	}

	private void OnTriggerExit(Collider col) {
		if (col.tag == "Wind") {
			Health--;
			HpBar.fillAmount = (float)Health / MAX_HEALTH;
		}
		if (col.tag == "Skill" && anti_Skill < 0) {
			Health -= 5;
			HpBar.fillAmount = (float)Health / MAX_HEALTH;
			anti_Skill = 1f;
		}
	}

	private void OnDestroy()
	{
		number--;
	}
}
