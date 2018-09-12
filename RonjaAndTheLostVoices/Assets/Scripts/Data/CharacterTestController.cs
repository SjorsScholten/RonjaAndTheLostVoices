using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTestController : MonoBehaviour {
    public LivingEntity character;
    public Text AttackText;
    public Text DefenseText;
    public Text HealthText;

    //
    public void AddStrModFlat() {
        character.attributes[(int)Stat.Attack].AddModifier(new StatModifier(1, StatModType.Flat, this));
        AttackText.text = character.attributes[(int)Stat.Attack].Value.ToString();
    }

    public void AddStrModAdd() {
        character.attributes[(int)Stat.Attack].AddModifier(new StatModifier(0.10f, StatModType.PercentAdd, this));
        AttackText.text = character.attributes[(int)Stat.Attack].Value.ToString();
    }

    public void AddStrModMulti() {
        character.attributes[(int)Stat.Attack].AddModifier(new StatModifier(0.25f, StatModType.PercentMulti, this));
        AttackText.text = character.attributes[(int)Stat.Attack].Value.ToString();
    }

    //
    public void AddDexModFlat() {
        character.attributes[(int)Stat.Defense].AddModifier(new StatModifier(1, StatModType.Flat, this));
        DefenseText.text = character.attributes[(int)Stat.Defense].Value.ToString();
    }

    public void AddDexModAdd() {
        character.attributes[(int)Stat.Defense].AddModifier(new StatModifier(0.10f, StatModType.PercentAdd, this));
        DefenseText.text = character.attributes[(int)Stat.Defense].Value.ToString();
    }

    public void AddDexModMulti() {
        character.attributes[(int)Stat.Defense].AddModifier(new StatModifier(0.25f, StatModType.PercentMulti, this));
        DefenseText.text = character.attributes[(int)Stat.Defense].Value.ToString();
    }

    //
    public void AddHpModFlat() {
        character.attributes[(int)Stat.Health].AddModifier(new StatModifier(1, StatModType.Flat, this));
        HealthText.text = character.attributes[(int)Stat.Health].Value.ToString();
    }

    public void AddHpModAdd() {
        character.attributes[(int)Stat.Health].AddModifier(new StatModifier(0.10f, StatModType.PercentAdd, this));
        HealthText.text = character.attributes[(int)Stat.Health].Value.ToString();
    }

    public void AddHpModMulti() {
        character.attributes[(int)Stat.Health].AddModifier(new StatModifier(0.25f, StatModType.PercentMulti, this));
        HealthText.text = character.attributes[(int)Stat.Health].Value.ToString();
    }

    //
    public void RemoveMods() {
        for (int i = 0; i < character.attributeAmount; i++) {
            character.attributes[i].RemoveAllModifersFromSource(this);
        }
        AttackText.text = character.attributes[(int)Stat.Attack].Value.ToString();
        DefenseText.text = character.attributes[(int)Stat.Defense].Value.ToString();
        HealthText.text = character.attributes[(int)Stat.Health].Value.ToString();
    }
}
