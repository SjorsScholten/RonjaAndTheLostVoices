using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default_Item", menuName = "Inventory/DefaultItem", order = 1)]
public class Item : ScriptableObject {
    public int id = -1;
    new public string name = "default item";
    public bool stackable = false;
    public int amount = 0;
    public string description = "";
}
