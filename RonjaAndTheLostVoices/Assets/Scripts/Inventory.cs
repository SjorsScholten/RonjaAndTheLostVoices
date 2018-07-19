using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Item> items = new List<Item>();

	public void AddItem(Item item) {
        Item listItem = items.Find(x => x.id == item.id);
        if (listItem != null) {
            listItem.value++;
        } else {
            items.Add(item);
        }
    }

    public void RemoveItem(Item item) {
        Item listItem = items.Find(x => x.id == item.id);
        if(listItem != null) {
            listItem.value--;
            if(item.value <= 0)
                items.Remove(item);
        }
    }

    public void MoveItem() {

    }

    public void EquipItem() {

    }
}
