using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
	AudioSource audiosrc;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
	Animator anim;


    void Awake ()
    {
		anim = GetComponent <Animator> ();
		audiosrc = GetComponent <AudioSource> ();
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
		//Debug.Log(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
			if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Attack")
				nav.enabled = false;
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
}
