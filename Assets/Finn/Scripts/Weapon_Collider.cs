using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Collider : MonoBehaviour {
	// Use this for initialization
	private Animator anim;
	string currentClip;
	PlayerController parentScript;
	bool markerEnable = false;
	//public EnemyHealth;
	public bool inRange = false;
	CapsuleCollider wep_collider;
	void Start () {
		wep_collider = GetComponent<CapsuleCollider> ();
		wep_collider.enabled = false;
		parentScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController> ();
		anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (parentScript.isMarkerEnable);
		markerEnable = parentScript.isMarkerEnable;
		currentClip = anim.GetCurrentAnimatorClipInfo (0) [0].clip.name;
		//Debug.Log (currentClip);
		//Debug.Log (markerEnable);
		if (currentClip == "Basic Attack" || currentClip == "Skill_1") {
			wep_collider.enabled = true;
		} else
			wep_collider.enabled = false;
		//int stateinfo = anim.GetCurrentAnimatorStateInfo (0).shortNameHash;
		//Debug.Log (anim.GetCurrentAnimatorClipInfo (0)[0].clip.name);
	}
		

	void OnTriggerEnter(Collider info){
		//Debug.Log (info.tag);
		//Debug.Log (markerEnable);
		//Debug.Log (info.name);
		//Debug.Log (currentClip);
		//Debug.Log(info.tag);
		/*
		if (currentClip == "Basic Attack" && info.tag == "Enemy") {
			Debug.Log ("Hit");
			EnemyHealth enemyhealth = info.GetComponent<EnemyHealth> ();
			if (enemyhealth != null) {
				enemyhealth.TakeDamage (10);
			}
		}
		*/
		//Debug.Log (info.tag);
		if ((info.tag == "Enemy" || info.tag == "Boss") && currentClip == "Basic Attack" && markerEnable) {
			//Debug.Log ("Hit");
			if (info.tag == "Boss") {
				BossHealth bossHealth = info.GetComponent<BossHealth> ();
				bossHealth.TakeDamage (30);
			}
		
		else {
				EnemyHealth enemyHealth = info.GetComponent<EnemyHealth> ();
				enemyHealth.TakeDamage (40);
			}
			/*
		} else if ((info.tag == "Enemy" || info.tag == "Boss") && currentClip == "Skill_1" && markerEnable) {
			//Debug.Log ("Skill 1");
			if (info.tag == "Boss") {
				BossHealth bossHealth = info.GetComponent<BossHealth> ();
				bossHealth.TakeDamage (75);
			} else {
				EnemyHealth enemyHealth = info.GetComponent<EnemyHealth> ();
				enemyHealth.TakeDamage (75);
			}
			*/
		}

	}
	void OnTriggerStay(Collider info){
		if ((info.tag == "Enemy" || info.tag == "Boss") && currentClip == "Skill_1" && markerEnable) {
			if (info.tag == "Boss") {
				BossHealth bossHealth = info.GetComponent<BossHealth> ();
				bossHealth.TakeDamage (2);
			} else {
				EnemyHealth enemyHealth = info.GetComponent<EnemyHealth> ();
				enemyHealth.TakeDamage (10);
			}
		}
	}
		
}
