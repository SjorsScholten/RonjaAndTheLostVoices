using System;
using System.Collections.Generic;
using UnityEngine;

public enum Stat { Health, Attack, Defense}

public class LivingEntity : MonoBehaviour {
    new public string name = "Living Entity";

    public CharacterStat[] attributes;
    public int attributeAmount;

    private void Start() {
        attributeAmount = Enum.GetNames(typeof(Stat)).Length;
        attributes = new CharacterStat[attributeAmount];

        for (int i = 0; i < attributeAmount; i++) {
            attributes[i] = new CharacterStat(10);
        }
    }
    
}
