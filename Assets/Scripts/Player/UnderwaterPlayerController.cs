using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class UnderwaterPlayerController : MonoBehaviour
{
    CharacterController character;

    public float speed, normalSpeed = 7f, reducedSpeed = 5f, runningIncreaseSpeed = 0f;
    public float moveFB, moveLR;
    public Vector3 velocity;
    public float jumpHeight = 2f;
    public bool isSwimming = false;
    public float gravity = -9.81f;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }


    void Update()
    {
        runningIncreaseSpeed = Mathf.Clamp(runningIncreaseSpeed, 0, 7);

        if (Input.GetKeyDown(KeyCode.LeftShift))
            isSwimming = true;

        if (Input.GetKeyUp(KeyCode.LeftShift))
            isSwimming = false;

        if (isSwimming && runningIncreaseSpeed < 7)
            runningIncreaseSpeed += 5.5f * Time.deltaTime;

        if (!isSwimming && runningIncreaseSpeed > 0)
            runningIncreaseSpeed -= 6.5f * Time.deltaTime;

        moveLR = Input.GetAxis("Horizontal");
        moveFB = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * moveLR + transform.forward * moveFB;

        speed = moveLR != 0 ? reducedSpeed : normalSpeed;
        speed += runningIncreaseSpeed;

        character.Move(movement * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        character.Move(velocity * Time.deltaTime);
    }
}
