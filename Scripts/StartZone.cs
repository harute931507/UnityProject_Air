using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartZone : MonoBehaviour {

	public GameObject master;
	public GameObject startPanel;
	public GameObject Start_Bell;

	private bool noVoice = true;


	void OnTriggerExit(Collider col) {
		if (col.tag == "wind") {
			return;
		}
		gameObject.GetComponent<BoxCollider> ().isTrigger = false;
		master.SetActive (true);
		if (noVoice) {
			GetComponent<AudioSource> ().Play ();
			noVoice = !noVoice;
		}
		/*if (bell) {
			bell = false;
			Instantiate (Start_Bell, transform.position, Quaternion.identity);
		}*/
		startPanel.SetActive (false);

	}
}
