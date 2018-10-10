using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class monster : MonoBehaviour {
	public GameObject player;
	public Transform eyes;
	public AudioSource growl;


	private NavMeshAgent nav;
	//private AudioSource sound;
	private Animator anim;
	private string state = "idle";
	private bool alive = true;


	// Use this for initialization
	void Start ()
	{
		nav = GetComponent<NavMeshAgent> ();
		//sound = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
		//travel speed of the monster
		nav.speed = 1.2f;
		anim.speed = 1.2f;
	}
	//Can the monster see the player
	public void checkSight()
	{
		if (alive) {
			RaycastHit rayHit;
			if (Physics.Linecast (eyes.position, player.transform.position, out rayHit))
			{
				//print ("hit " + rayHit.collider.gameObject.name);
				if (rayHit.collider.gameObject.name == "player")
				{
					if (state != "kill") {
						state = "chase";
						nav.speed = 2.5f;
						anim.speed = 2.5f;
						growl.pitch = 1.2f;
						growl.Play ();
					}
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.DrawLine (eyes.position, player.transform.position, Color.green);
		if (alive)
		{
			anim.SetFloat ("velocity", nav.velocity.magnitude);
			//idle
			//checkSight(); 
			if (state == "idle") 
			{
				//pick a random place to walk to
				Vector3 randomPos = Random.insideUnitSphere*20f;
				NavMeshHit navHit;
				NavMesh.SamplePosition (transform.position + randomPos, out navHit, 20f, NavMesh.AllAreas);
				nav.SetDestination (navHit.position);
				state = "walk";
			}
		//walk
			if (state == "walk") 
			{
				if (nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending) 
				{
					state = "idle";
				}
			}
		//chase
			if (state=="chase")
			{
				nav.destination = player.transform.position;
			}

			//nav.SetDestination (player.transform.position);
		}
	}

}