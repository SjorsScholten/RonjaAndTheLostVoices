using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CharacterController))]
[RequireComponent (typeof (Animator))]
public class ThirdPersonController : MonoBehaviour {
    //walking atributes
    public float walkSpeed = 2;
    public float runSpeed = 6;
    public float speedSmoothTime = 0.1f;
    private float speedSmoothVelocity;
    private float currentSpeed;

    //jumping atributes
    public float jumpHeight = 1;
    [Range(0, 1)] public float airControlPercent;
    public float gravity = -12;
    private float velocityY;

    //turning atributes
    public float turnSmoothTime = 0.2f;
    private float turnSmoothVelocity;

    Transform cameraT;
    CharacterController character;
    Animator animator;

	protected void Start () {
        //base.Start();
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        cameraT = Camera.main.transform;
	}

    void Update() {

        //Movement input
        Vector2 input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            );
        Vector2 inputDir = input.normalized;

        //Jump Input
        bool jumpinput = Input.GetButtonDown("Jump");
        if (jumpinput) { Jump(); }

        if (inputDir != Vector2.zero) { Rotate(inputDir); }

        //Running input
        bool running = Input.GetKey(KeyCode.LeftShift);

        //Moving Player based on Input
        Move(running, inputDir);

        //Interaction Input
        bool interacting = Input.GetButtonDown("Interact");
        if (interacting) { PickUp(); }

        //animation
        float animationPercent = ((running) ? currentSpeed / runSpeed : currentSpeed / walkSpeed * 0.5f);
	}

    private void Jump() {
        if (character.isGrounded) {
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight); //Calculate velocity for assigned jumpheight 
            velocityY = jumpVelocity; //Apply jumpvelocity to movement
        }
    }

    private void Move(bool running, Vector2 direction) {
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * direction.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));

        velocityY += Time.deltaTime * gravity; //Apply gravity

        Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY; //Calculate velocity
        character.Move(velocity * Time.deltaTime); //Apply velocity to the player
        currentSpeed = new Vector2(character.velocity.x, character.velocity.z).magnitude; //Reference speed for smoothing

        if (character.isGrounded) { velocityY = 0; } //When grounded stop falling
    }

    private void Rotate(Vector2 direction) {
        float targetRotation = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y; //Calculate rotation
        float rotationSmooth = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime)); //smooth rotation
        transform.eulerAngles = Vector3.up * rotationSmooth; //Apply rotation to player
    }

    private void PickUp() {

    }

    private float GetModifiedSmoothTime(float smoothTime) {
        if (character.isGrounded) { return smoothTime; } 
        if (airControlPercent == 0) { return float.MaxValue; } 
        return smoothTime / airControlPercent;
    }

}
