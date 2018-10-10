using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLuna : MonoBehaviour {

	private Animator anim;// reference to the Animator tab in Unity.
	private CharacterController controller;//reference to the CharacterController tab
	//in unity.
	public float speed = 6.0f;//shows up in the inspector in Unity.
	public float turnspeed = 60.0f;
	private Vector3 moveDirection = Vector3.zero;
	public float gravity = 20.0f;

	// Use this for initialization
	void Start () 
	{
		anim = gameObject.GetComponentInChildren<Animator> ();
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey ("up")) 
		{
			anim.SetInteger ("AnimPar", 1);
		} 
		else
		{
			anim.SetInteger ("AnimPar", 0);
		}
		if (controller.isGrounded) 
		{
			moveDirection = transform.forward * Input.GetAxis ("Vertical") * speed;
		}
		float turn = Input.GetAxis ("Horizontal");
		transform.Rotate (0, turn * turnspeed * Time.deltaTime, 0);
		controller.Move (moveDirection * Time.deltaTime);
		moveDirection.y -= gravity * Time.deltaTime;


		if (Input.GetKey (KeyCode.J)) { //if we press J
			anim.SetBool ("jump", true);
		} 
		else 
		{
			anim.SetBool ("jump", false);

		}

		if (Input.GetKey (KeyCode.F)|| Input.GetKeyDown ("1")|| Input.GetKeyDown ("2") ) { //if we press the F key, 1, or 2
			anim.SetBool ("cast spell attack", true);
		} 
		else 
		{
			anim.SetBool ("cast spell attack", false);

		}

	}
}
