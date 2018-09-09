using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentSlot { Hands, Clothes};

public class Equipment : MonoBehaviour {

    public Equipable[] equipmentSlots;
    private int amountOfSlots;


    void Start () {
        amountOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        equipmentSlots = new Equipable[amountOfSlots];
	}

    public void Equip(Equipable equipable) {
        int slotIndex = (int)equipable.slot;
        Unequip(slotIndex);
        equipmentSlots[slotIndex] = equipable;
    }

    public void Unequip(int slotIndex) {
        if(equipmentSlots[slotIndex] != null) {
            //Equipable old = equipmentSlots[slotIndex];
            equipmentSlots[slotIndex] = null;
        }
    }

    public void UnequipAll() {
        for (int i = 0; i < amountOfSlots; i++) {
            Unequip(i);
        }
    }
}
