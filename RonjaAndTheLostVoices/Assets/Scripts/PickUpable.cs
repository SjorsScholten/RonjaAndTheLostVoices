using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpable : Interactable {
    public Item item;

    public override void Interract() {
        base.Interract();
        PickUp();
    }

    private void PickUp() {
        Debug.Log("picking up " + item.name);
        //add to inventory
    }
}
