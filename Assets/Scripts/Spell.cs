using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : ScriptableObject

{
	public string spellName = "";
	public GameObject spellPrefab = null;
	public GameObject spellCollisionParticle = null;
	public Texture2D spellIcon = null;

	public int spellManaCost = 0;
	public int spellMinDamage = 0;
	public int spellMaxDamage = 0;
	public int projectileSpeed = 0;
}
