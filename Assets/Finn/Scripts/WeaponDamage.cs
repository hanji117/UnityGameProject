using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour {
	Weapon_Collider wep_col;
	PlayerController play_controller;
	public int Damage = 10;
	// Use this for initialization
	void Start () {
		wep_col = GetComponentInChildren<Weapon_Collider> ();
		play_controller = GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Attack (){
		
	}
}
