using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	public List<Item> items = new List<Item>();
	public int slots = 20;
	public int maxItemCapacity = 999;

	public bool AddItem(Item item) {
		//pull item from list
        Item listItem = items.Find(x => x.id == item.id);

		//check if item is found
        if (listItem == null) {
			//item is not found
			//add item as new
			return AddNewItem(item);
        }
		//item is found

		//check if item is stackable
		if (!listItem.stackable) {
			//item is not stackable
			//add item as new
			return AddNewItem(item);
		}
		//item is stackable

		//check if addition is greater or equal as the max item capacity
		if (listItem.amount + item.amount >= maxItemCapacity) {
			//addition is greater or equal as the max item capacity
			listItem.amount = maxItemCapacity;
			Debug.Log ("");
			return true;
		}
		//addition is less than the max item capacity

		//add amount to the item
		listItem.amount += item.amount;
		Debug.Log ("");
		return true;
    }

	public bool RemoveItem(Item item) {
		//pull item from list
        Item listItem = items.Find(x => x.id == item.id);
		//check if item is found
        if(listItem == null) {
			//item is not found
			Debug.Log ("");
			return false;
        }
		//item is found



		return true;
    }

	public void MoveItem(Item oldLocation, Item newLocation) {
		int indexOld = items.FindIndex (x => x.id == oldLocation.id);
		int indexNew = items.FindIndex (x => x.id == newLocation.id);
		items.Insert (indexOld, newLocation);
		items.Insert (indexNew, oldLocation);
    }

    public void EquipItem() {

    }

	public bool CheckForItem(Item item){
        return false;
	}

	public bool AddNewItem(Item item){
		//check if there are slots available
		if (slots - items.Count <= 0) {
			//no slots available
			Debug.Log ("");
			return false;
		}
		//slots available

		//add item as new
		items.Add (item);
		Debug.Log ("");
		return true;
	}
}
