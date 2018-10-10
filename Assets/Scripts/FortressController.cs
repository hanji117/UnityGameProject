using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressController : MonoBehaviour {
	Animator anim;
	QuestManager questManager;
	AudioSource audioSRC;
	public int EnemyRequired = 10;
	bool isOpen = false;
	// Use this for initialization
	void Start () {
		audioSRC = GetComponent<AudioSource> ();
		//audiosrc.Play ();
		questManager = GameObject.FindGameObjectWithTag ("QuestManager").GetComponent<QuestManager> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (questManager.numEnemiesKilled >= EnemyRequired && !isOpen) {
			isOpen = true;
			OpenGate ();
			//audiosrc.Play ();
			//anim.SetTrigger ("openIt");
		}
	}
	void OpenGate(){
		audioSRC.Play ();
		anim.SetTrigger ("openIt");
	}
}
