using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	//Walking parameters
	public float walkSpeed = 2;
	public float runSpeed = 6;
	float gravity = -9.81f;
	float velocityY;
	public float turnSmoothTime = 0.2f;
	float turnSmoothVelocity;
	public float speedSmoothTime = 0.1f;
	float speedSmoothVelocity;
	float currentSpeed;
	int floorMask;
	float camRayLength = 100f;

	//Animation parameters
	//Collider wep_collider;
	Animator animator;
	CharacterController controller;
	int basicAttackHash = Animator.StringToHash("Basic Attack");
	int skill1Hash = Animator.StringToHash("Skill 1");
	public bool animIsPlaying = false;
	public bool isMarkerEnable = false;
	//Sound parameters
	public AudioClip[] atk_animClip;
	public AudioClip[] foot_stepsClip;
	public AudioSource audioSrc;

	// Use this for initialization
	void Start () {
		floorMask = LayerMask.GetMask ("Floor");
		//wep_collider = transform.FindChild ("Weapon Collider").GetComponent<Collider> ();
		audioSrc = GetComponent<AudioSource> ();
		animator = GetComponent<Animator> ();
		controller = GetComponent<CharacterController> ();
	}
		
	// Update is called once per frame
	void Update () {
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		Vector2 inputDir = input.normalized;
		int stateinfo = animator.GetCurrentAnimatorStateInfo (0).shortNameHash;

		if (stateinfo == basicAttackHash || stateinfo == skill1Hash) {
			//Debug.Log ("I attack");
			controller.Move (Vector3.zero);
			animIsPlaying = true;
		} else {
			Move (inputDir);
			animIsPlaying = false;
		}

		//Input section
		if (Input.GetMouseButtonDown (0) && animIsPlaying == false) {
			Turning ();
			animator.SetBool ("attack", true);
			int gruntSound;
			gruntSound = Random.Range (2, 4);
			PlaySound (0);
			PlaySound (gruntSound);
		} else {
			animator.SetBool ("attack", false);
		}

		if (Input.GetMouseButtonDown (1) && animIsPlaying == false) {
			Turning ();
			animator.SetBool ("skill1", true);
			PlaySound (1);
		}
		else
			animator.SetBool ("skill1", false);


		//Animation section
		float animationSpeedPercent = currentSpeed/runSpeed;
		animator.SetFloat ("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
	}

	//Chracter move function
	void Move (Vector2 inputDir){
		if (inputDir != Vector2.zero) {
			float targetRotation = Mathf.Atan2 (inputDir.x, inputDir.y) * Mathf.Rad2Deg;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle (transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
		}

		float targetSpeed = runSpeed * inputDir.magnitude;
		currentSpeed = Mathf.SmoothDamp (currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);
		velocityY += Time.deltaTime * gravity;
		Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;
		//transform.Translate (transform.forward * currentSpeed * Time.deltaTime, Space.World);
		controller.Move (velocity * Time.deltaTime);
		currentSpeed = new Vector2 (controller.velocity.x, controller.velocity.z).magnitude;
		if (controller.isGrounded) {
			velocityY = 0.0f;
		}
	}

	void Turning(){
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			transform.rotation = newRotation;
		}
	}
	//Walking animation sound effects
	void Steps(){
		AudioClip clip = null;
		float maxvol = 1.0f;
		RaycastHit hit;
		//Debug.DrawRay (transform.position, Vector3.up, Color.green);
		if (Physics.Raycast (transform.position, -Vector3.up, out hit, 10.0f)) {
			if (hit.collider.CompareTag ("Ground")) {
				clip = foot_stepsClip [0];
				maxvol = UnityEngine.Random.Range (0.6f, 1f);
			} else if (hit.collider.CompareTag ("Walkway")) {
				clip = foot_stepsClip [1];
				maxvol = UnityEngine.Random.Range (0.6f, 1f);
			}
		}
		if (clip != null)
			audioSrc.PlayOneShot (clip, maxvol);
	}

	//Action animation sound effects
	void PlaySound(int clip_toPlay){
		float maxvol = 1.0f;
		if (clip_toPlay == 3)
			audioSrc.PlayOneShot (atk_animClip [clip_toPlay], 0.4f);
		else if(clip_toPlay == 2)
			audioSrc.PlayOneShot (atk_animClip [clip_toPlay], 0.4f);
		else {
			maxvol = UnityEngine.Random.Range (0.2f, 0.3f);
			audioSrc.PlayOneShot (atk_animClip [clip_toPlay], maxvol);
		}
	}

	void EnableMarker(){
		isMarkerEnable = true;
	}

	void DisableMarker(){
		isMarkerEnable = false;
	}

	void OnTriggerEnter(Collider exit){
		if (exit.tag == "Exit") {
			SceneManager.LoadScene ("Main World");
		} else if (exit.tag == "Town") {
			SceneManager.LoadScene ("Town");
		} else if (exit.tag == "BossBattle") {
			SceneManager.LoadScene ("BossBattle");
		} else if (exit.tag == "End") {
			SceneManager.LoadScene ("End");
		}
		//Debug.Log (exit.tag);
	}
}
