using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.tag == "Enemy") {
			EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth> ();
			enemyHealth.TakeDamage (55);
			//Destroy(collision.gameObject);
			//gameObject.SetActive(false);

		} else if (collision.tag == "Boss") {
			BossHealth bossHealth = collision.gameObject.GetComponent<BossHealth> ();
			bossHealth.TakeDamage (30);
		}
	}
}
