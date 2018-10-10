using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform Target;
	// Use this for initialization
	void Start () {
		Target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3 (Target.position.x, transform.position.y, Target.position.z);
	}
}
