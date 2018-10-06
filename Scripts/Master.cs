using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Master : MonoBehaviour {

	// Score
	public static int score;
	public Text scoreTxt;
	public int breaker_score;

	// Start Panel
	public GameObject startPanel;

	// Enemy
	public GameObject enemy; 				
	public float maxEnemyNumber = 5f;
	public float enemySpawnInterval = 3f;	
	private float timer = 0;
	private bool change1;
	private bool change2;
	private bool change3;

	private void Start(){
		score = 0;
		score = breaker_score;
		change1 = true;
		change2 = true;
		change3 = true;
	}


	void Update () {
		
		maxEnemyNumber += Time.deltaTime / 14f;

		if (score > 500 & score < 800 & change1) {
			enemySpawnInterval = 4f;
			change1 = false;
		} 
		if (score > 800 & score < 1000 & change2) {
			enemySpawnInterval = 5f;
			change2 = false;
		}
		if (score > 1000 & change3) {
			enemySpawnInterval = 6f;
			FirstPersonController.ATField = true;
			change3 = false;
		} 

		// Enemy Spawn
		if (Enemy.number < maxEnemyNumber) {
			timer += Time.deltaTime;				
			if (timer > enemySpawnInterval) {		
				timer = 0;							
				Instantiate (enemy, new Vector3 (20f + Random.value * 60f, 2f, 20f + Random.value * 60f), Quaternion.identity);
				Enemy.number++;						
			}
		}

		scoreTxt.text = "Score: " + score;
	}

	public void Restart()
	{
		Debug.Log ("Restart");
		SceneManager.LoadScene ("scene", LoadSceneMode.Single);		
		Master.score = 0;
		startPanel.SetActive (true);
		gameObject.SetActive (false);
	}
}
