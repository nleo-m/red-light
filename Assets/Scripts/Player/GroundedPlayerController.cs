using UnityEngine;


public class GroundedPlayerController : MonoBehaviour
{
    CharacterController character;

    public float speed, normalSpeed = 7f, reducedSpeed = 5f, runningBoost = 0f;
    public float moveFB, moveLR;
    public Vector3 velocity;
    public float jumpHeight = 2f;
    public bool isRunning = false, isGrounded = false;
    
    float gravity = -9.81f;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }


    void Update()
    {
        runningBoost = Mathf.Clamp(runningBoost, 0, 7);

        isGrounded = character.isGrounded;
        isRunning = Input.GetKey(KeyCode.LeftShift);

        if (isRunning && runningBoost < 7)
            runningBoost += 5.5f * Time.deltaTime;

        if (!isRunning && runningBoost > 0)
            runningBoost -= 6.5f * Time.deltaTime;

        moveLR = Input.GetAxis("Horizontal");
        moveFB = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * moveLR + transform.forward * moveFB;

        speed = moveLR != 0 ? reducedSpeed : normalSpeed;
        speed += runningBoost;

        character.Move(movement * speed * Time.deltaTime);

        if (Input.GetButtonUp("Jump") && isGrounded)
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);

        if (isGrounded && velocity.y < 0)
            velocity.y = 0;

        velocity.y += gravity * Time.deltaTime;
        character.Move(velocity * Time.deltaTime);
    }
}
