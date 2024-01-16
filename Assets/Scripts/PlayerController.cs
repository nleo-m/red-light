using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class PlayerController : MonoBehaviour {

	CharacterController character;
	Camera cam;

	public float speed, normalSpeed = 7f, reducedSpeed = 5f, runningIncreaseSpeed = 0f;
	public float moveFB, moveLR;
	public Vector3 velocity;
	public float jumpHeight = 2f;
	public bool isRunning = false;
	public float gravity = -9.81f;
	public float waterHeight = 15.5f;
	public bool isGrounded = true;

    public float mouseSensitivity = 100f;
	float mouseX, mouseY, vRotation = 0;
	private float minVRotation = -45f;
	private float maxVRotation = 75f;


	void Start(){
		character = GetComponent<CharacterController> ();
		cam = GetComponentInChildren<Camera>();
	}


	void CheckForWaterHeight(){
		if (transform.position.y < waterHeight)
		{
			gravity = 0f;
			PlayerState.isUnderWater = true;
		} else
		{
            gravity = -9.81f;
			PlayerState.isUnderWater = false;
        }
	}



	void Update(){
		mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
		
		vRotation -= mouseY;
		vRotation = Mathf.Clamp(vRotation, minVRotation, maxVRotation);

		runningIncreaseSpeed = Mathf.Clamp(runningIncreaseSpeed, 0, 7);
		
		CameraRotation ();

		if (Input.GetKeyDown(KeyCode.LeftShift))
			isRunning = true;
				
		if (Input.GetKeyUp(KeyCode.LeftShift))
			isRunning = false;

		isGrounded = character.isGrounded ? true : false;

		if (isRunning && runningIncreaseSpeed < 7)
			runningIncreaseSpeed += 5.5f * Time.deltaTime;

		if (!isRunning && runningIncreaseSpeed > 0)
			runningIncreaseSpeed -= 6.5f * Time.deltaTime;

		moveLR = Input.GetAxis ("Horizontal");
		moveFB = Input.GetAxis ("Vertical");
		
		Vector3 movement = transform.right * moveLR + transform.forward * moveFB;

		speed = moveLR != 0 ? reducedSpeed : normalSpeed;
		speed += runningIncreaseSpeed;

		character.Move (movement * speed * Time.deltaTime);

		if (Input.GetButtonDown("Jump") && isGrounded)
			velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);

		if (isGrounded && velocity.y < 0)
			velocity.y = 0;

		velocity.y += gravity * Time.deltaTime;
		character.Move(velocity * Time.deltaTime);

		CheckForWaterHeight();
	}


	void CameraRotation(){		
		cam.transform.localRotation = Quaternion.Euler(vRotation, 0f, 0f);
		transform.Rotate(Vector3.up * mouseX);
	}
}
