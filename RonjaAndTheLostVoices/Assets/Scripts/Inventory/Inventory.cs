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
		Debug.Log ("item added to inventory, current amount is: " + items.Find(x => x.id == item.id).amount);
		return true;
    }

	public bool RemoveItem(Item item) {
        //search for item in inventory
        Item invItem = items.Find(x => x.id == item.id);
        //check if item is in inventory
        if (invItem == null) {
            //item is not in inventory
            Debug.Log("cant find item with id: " + item.id);
            return false;
        }
        //item is in inventory

        //check if the substracted amount is lower as 0
        if (invItem.amount - item.amount < 0) {
            //substracted amount is below 0
            Debug.Log("cant substract amount below 0, current amount: " + invItem.amount + ", amount to substract: " + item.amount);
            return false;
        }
        //substracted amount is higher or equal as 0

        //substract amount from amount in inventory
        invItem.amount -= item.amount;

        //check if item amount is lower or equal as 0
        if (invItem.amount <= 0) {
            //item amount is lower or equal as 0
            items.Remove(invItem);
            Debug.Log("new slot AVAILABE, amount of slots: " + (slots - items.Count));
        }
        //item amount is greater as 0
        return true;
    }

    public bool AddNewItem(Item item) {
        //check if there are slots available
        if (slots - items.Count <= 0) {
            //no slots available
            Debug.Log("");
            return false;
        }
        //slots available

        //add item as new
        items.Add(item);
        Debug.Log("");
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

	
}
