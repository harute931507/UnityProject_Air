using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public Transform Center;
	public float Nx;
	public float Ny;
	public float Nz;
	public float Speed;

	private Vector3 Normal;

	void Start () {
		Normal = new Vector3 (Nx, Ny, Nz);
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (Center.position, Normal,Speed * Time.deltaTime );
	}
}
