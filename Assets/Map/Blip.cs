using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blip : MonoBehaviour {
	public Transform target;
	public bool KeepInBounds = true;
	MiniMap map;
	RectTransform myRectTransform;
	// Use this for initialization
	void Start () {
		map = GetComponentInParent<MiniMap> ();
		myRectTransform = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector2 newPosition = map.TransformPosition (target.position);
		myRectTransform.localPosition = newPosition;
		if (KeepInBounds)
			newPosition = map.MoveInside (newPosition);
	}
}
