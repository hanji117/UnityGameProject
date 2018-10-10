using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastSpell : MonoBehaviour
{
	public Transform magicSpawn;

	Spell spell;
	PlayerHealth playerhealth;
	PlayerController playercontroller;
	public List<Spell> spellList = new List<Spell>();
	float timer;
	public int mana = 200;
	public int skill1_cost = 50;
	public Slider manaslider; 
	void Start()
	{
		playerhealth = GetComponent<PlayerHealth> ();
		playercontroller = GetComponent<PlayerController> ();
		spell = (Spell)Resources.Load("Spells/" + gameObject.name, typeof(Spell));
		manaslider.value = mana;
		List<Spell> spellDatabase = GameObject.Find("SpellManager").GetComponent<SpellManager>().spellList;

		for (int i = 0; i < spellDatabase.Count; i++)
		{
			spellList.Add(spellDatabase[i]);
		}

	}

	void LateUpdate()
	{
		if(Input.GetMouseButtonDown (0) && playercontroller.animIsPlaying == false && playerhealth.currentHealth > 0)
		{
			CastMagic (spellList [0]);
			if (spell != null)
				CastMagic (spell);

		}

		if (Input.GetMouseButtonDown (1) && playercontroller.animIsPlaying == false && playerhealth.currentHealth > 0) 
		{
			if (mana >= skill1_cost) {
				mana -= skill1_cost;
				manaslider.value = mana;
				CastMagic (spellList [1]);
				if (spell != null)
					CastMagic (spell);
			}
		}

		if (Input.GetKeyDown ("q")) 
		{
			CastMagic (spellList [2]);
			if (spell != null)
				CastMagic (spell);
		}
	}

	void CastMagic(Spell spell)
	{
		if (spell.spellPrefab == null) {
			Debug.LogWarning ("Spell prefab is null! Must assign as spell prefab!");
			return;
		} else {
			//GameObject spellObject = Instantiate (spell.spellPrefab, magicSpawn.position, Camera.main.GetComponent<Transform> ().rotation);
			GameObject spellObject = Instantiate (spell.spellPrefab, magicSpawn.position, magicSpawn.rotation);
			spellObject.AddComponent<Rigidbody> ();
			spellObject.GetComponent<Rigidbody> ().useGravity = false;
			spellObject.GetComponent<Rigidbody> ().velocity = spellObject.transform.forward * spell.projectileSpeed;
			spellObject.name = spell.spellName;
			spellObject.transform.parent = GameObject.Find ("SpellManager").transform;

			Destroy (spellObject, 2); // 2 sec
		}
	}
}
