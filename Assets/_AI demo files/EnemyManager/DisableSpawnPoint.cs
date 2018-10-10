using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSpawnPoint : MonoBehaviour {
	public bool Spawnable = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider info){
		if(info.tag == "Player")
			Spawnable = false;
	}

	void OnTriggerExit(Collider info){
		if (info.tag == "Player") {
			Spawnable = true;
		}
	}
}
