using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonInteract : MonoBehaviour {
	public float reach = 3;
	public Transform grabOrigin;
	public RaycastHit[] objectsInRange;

	void Start () {
		
	}

	void Update () {
		Ray ray = new Ray (grabOrigin.position, grabOrigin.forward);
		objectsInRange = Physics.SphereCastAll (ray, reach);

		if(true){
			
		}
	}

	public void PickUp(){
		
	}

	public Transform GetClosestObject(Transform[] objects){
		Transform closestObject = null;
		float distance = Mathf.Infinity;
		foreach (Transform o in objects) {
			if (true) {
				
			}
		}
		return null;
	}
}
