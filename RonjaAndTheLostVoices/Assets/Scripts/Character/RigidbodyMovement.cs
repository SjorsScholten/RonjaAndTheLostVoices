using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMovement : MonoBehaviour, IMovement {
    //Walk atributes
    [Header("Walk properties")]
    public float walkSpeed = 2;
    public float runSpeed = 6;
    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;

    //jump atributes
    [Header("Jump properties")]
    public float jumpSpeed = 15;
    [Range(0, 1)] public float airControlPercent;
    float distToGround;

    //turn atributes
    [Header("Turn properties")]
    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    //Components
    Transform _transform = null;
    Collider _collider = null;
    Rigidbody _rigidbody = null;
    Transform _camera = null;

    private void Start() {
        _transform = GetComponent<Transform>();
        _camera = Camera.main.transform;
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        distToGround = _collider.bounds.extents.y;
    }

    //Make the Character move forward
    public void Move(bool running, Vector2 motion) {
        //determine target speed
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * motion.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));
        
        //determine velocity of the player
        Vector3 velocity = _transform.forward * currentSpeed;
        
        //apply speed to rigidbody
        _rigidbody.MovePosition(_transform.position + velocity * Time.deltaTime);
        
        //set velocity for further refrence
        currentSpeed = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.z).magnitude;
    }

    //Change characters walking direction
    public void Rotate(Vector2 direction) {
        //Calculate rotation
        float targetRotation = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + _camera.eulerAngles.y;
        
        //smooth rotation
        float rotationSmooth = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime)); 
        _rigidbody.MoveRotation(Quaternion.Euler(Vector3.up*rotationSmooth));
    }

    //Make the Character Jump
    public void Jump() {
        //check if character is grounded
        if (IsGrounded()) {
            //character is grounded add force up
            Debug.Log("add jump force");
            _rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    public bool IsGrounded() {
        //create a ray
        Ray ray = new Ray(_transform.position + Vector3.up * distToGround, -Vector3.up);
        
        //check distence to ground
        return Physics.Raycast(ray, distToGround + 0.1f);
    }

    private float GetModifiedSmoothTime(float smoothTime) {
        if (IsGrounded()) { return smoothTime; }
        if (airControlPercent == 0) { return float.MaxValue; }
        return smoothTime / airControlPercent;
    }
}
