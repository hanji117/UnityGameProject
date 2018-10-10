using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {
	PlayerHealth playerHealth;
	Slider slider;
	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();
		slider.maxValue = playerHealth.startingHealth;
		slider.value = playerHealth.startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
