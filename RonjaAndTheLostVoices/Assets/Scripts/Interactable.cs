using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    private float radius = 3;
    private bool isFocused = false;
    private Transform player;
    private bool hasInterracted = false;

    private void Update() {
        if (isFocused && !hasInterracted) {
            float distance = Vector3.Distance(player.position, transform.position);
            if(distance <= radius) {
                Interract();
                hasInterracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform) {
        isFocused = true;
        player = playerTransform;
        hasInterracted = false;
    }

    public void OnDeFocused() {
        isFocused = false;
        player = null;
        hasInterracted = false;
    }

    public virtual void Interract() {
        Debug.Log("interacting with " + transform.name);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
