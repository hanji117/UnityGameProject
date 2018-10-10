using UnityEngine;
using System.Collections;
public class CameraController : MonoBehaviour 
{
	public GameObject player;  //The offset of the camera to centrate the player in the X axis
	private Vector3 offset;
	public float offsetX = -5;  //The offset of the camera to centrate the player in the Z axis
	public float offsetZ = 0;  //The maximum distance permited to the camera to be far from the player, its used to     make a smooth movement
	public float offsetY = 5;
	public float maximumDistance = 2;  //The velocity of your player, used to determine que speed of the camera
	public float playerVelocity = 10;
	//private int index;
	private float movementX;
	private float movementZ;
	private float movementY;
	private Vector3 rayDestination;

	RaycastHit hit;
	// Update is called once per frame
	void Start (){
		//index = PlayerPrefs.GetInt ("CharacterSelected");
		player = GameObject.FindGameObjectWithTag ("Player");
		offset = transform.position - player.transform.position;
	}


	void Update () 
	{
		rayDestination = player.transform.position;
		rayDestination.y += 2;
		//Debug.DrawLine(transform.position, rayDestination);
		/*
		if (Physics.Linecast (transform.position, rayDestination, out hit)) {
			if(hit.collider.tag != "Player" && hit.collider.tag != "Enemy")
				//hit.collider.gameObject.GetComponent<MeshRenderer> ().material.color = new Color (1f, 1f, 1f, 0.5f);
			//Debug.Log (hit.collider.tag);
		}
	*/
		/*
		movementX = ((player.transform.position.x + offsetX - this.transform.position.x))/maximumDistance;
		movementZ = ((player.transform.position.z + offsetZ - this.transform.position.z))/maximumDistance;
		movementY = player.transform.position.y + offsetY;
		//this.transform.position += new Vector3((movementX * playerVelocity * Time.deltaTime), movementY, (movementZ * playerVelocity * Time.deltaTime));
		transform.position = new Vector3(movementX, movementY, movementZ);
		*/
	}

	void LateUpdate() {
		transform.position = player.transform.position + offset;
	}
}