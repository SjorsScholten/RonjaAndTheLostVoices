using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    RigidbodyMovement movement;

    private void Start() {
        movement = GetComponent<RigidbodyMovement>();
    }

    private void Update () {

        //player walk input
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        Vector2 motion = new Vector2(horizontal, vertical).normalized;

        //Move Player
        if (motion != Vector2.zero) { movement.Rotate(motion); }
        movement.Move(Input.GetKey(KeyCode.LeftShift), motion);
	}

    private void FixedUpdate() {
        //player jump input
        if (Input.GetButtonDown("Jump")) { movement.Jump(); }
    }
}
