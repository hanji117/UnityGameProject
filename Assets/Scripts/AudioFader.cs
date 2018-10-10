using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFader : MonoBehaviour {
	AudioSource backgroundmusic;
	BossHealth bosshealth;
	bool bossIsDead = false;
	public float fadetime = 5f;
	float startvolume;
	// Use this for initialization
	void Start () {
		bosshealth = GameObject.FindGameObjectWithTag ("Boss").GetComponent<BossHealth> ();
		backgroundmusic = GetComponent<AudioSource> ();
		startvolume = backgroundmusic.volume;
	}
	
	// Update is called once per frame
	void Update () {
		if (bosshealth.currentHealth <= 0 && bossIsDead == false) {
			bossIsDead = true;
			while (backgroundmusic.volume > 0) {
				backgroundmusic.volume -= startvolume * Time.deltaTime / fadetime;
			}
			backgroundmusic.Stop ();
			backgroundmusic.volume = startvolume;
		}
	}
}
