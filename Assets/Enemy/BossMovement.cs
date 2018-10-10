using UnityEngine;
using System.Collections;

public class BossMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
	AudioSource audiosrc;
    BossHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
	Animator anim;
	public AudioClip[] boss_soundtracks;

    void Awake ()
    {
		anim = GetComponent <Animator> ();
		audiosrc = GetComponent <AudioSource> ();
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <BossHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
		//Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
			if (anim.GetCurrentAnimatorClipInfo (0) [0].clip.name == "Attack" || anim.GetCurrentAnimatorClipInfo (0) [0].clip.name == "Skill") {
				anim.SetBool ("Intro", false);
				nav.enabled = false;
			}
			else {
				nav.enabled = true;
				nav.SetDestination (player.position);
			}
        }
        else
        {
            nav.enabled = false;
        }
    }
	void PlayScream(){
		audiosrc.PlayOneShot (boss_soundtracks [0], 0.5f);
	}

	void Steps(){
		audiosrc.PlayOneShot (boss_soundtracks [1], 1f);
	}
}
