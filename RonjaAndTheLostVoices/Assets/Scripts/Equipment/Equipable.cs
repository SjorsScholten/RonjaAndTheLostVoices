using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipable : Item {
    public EquipmentSlot slot;

    public int InventoryModifier = 0;
    public int AttackModifier = 0;
    public int DefenseModifier = 0;
}
