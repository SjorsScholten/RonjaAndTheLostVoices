using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    new public string name;
    public float level;
    public float experience;

    private Attribute[] attributes = new Attribute[6];
    private Strength strength;
    private Dexterity dexterity;
    private Constitution constitution;

    //Stats
    private float health;
        //health = rnd(10) * lvl + con * lvl
    private float stamina;
        //
    private float mana;
        //


    //determined by items
    private float attack;
    private float defense;
    private float magickalAttack;
    private float magickalDefense;

    //temporary modifiers
    private float buff;
    private float debuff;

    public void AddExperience(float amount) {
        //add experience
        //check if level up available
    }

    public void LevelUp() {
        //add level
        //increase stats
    }

    public void AddLevel() {

    }
}
