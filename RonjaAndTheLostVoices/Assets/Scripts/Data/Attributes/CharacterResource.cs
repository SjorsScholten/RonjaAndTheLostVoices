using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Timers;
using System;
using UnityEngine;

public class CharacterResource : CharacterStat {
    private float currentValue;
    new bool isDirty = true;
    private Timer timer;

    private readonly List<ResourceModifer> resourceModifiers;
    public readonly ReadOnlyCollection<ResourceModifer> ResourceModifiers;

    public CharacterResource() : base(){
        resourceModifiers = new List<ResourceModifer>();
        ResourceModifiers = resourceModifiers.AsReadOnly();

        timer = new Timer();
        timer.Elapsed += new ElapsedEventHandler(OnTimeEvent);
        timer.Interval = 1000;
        timer.Enabled = false;
    }

    public CharacterResource(float value) : base(value) {
        this.currentValue = value;
    }

    public void AddModifier(ResourceModifer mod) {
        resourceModifiers.Add(mod);
        resourceModifiers.Sort(CompareModifierOrder);
        timer.Enabled = true;
    }

    public bool RemoveModifier(ResourceModifer mod) {
        if (resourceModifiers.Remove(mod)) {
            this.isDirty = true;
            if(resourceModifiers.Count <= 0) {
                timer.Enabled = false;
            }
            return true;
        }
        return false;
    }

    private void OnTimeEvent(object source, ElapsedEventArgs e) {
        for (int i = 0; i < resourceModifiers.Count; i++) {

            ResourceModifer mod = resourceModifiers[i];

            if (TimeSpan.Compare(DateTime.Now - mod.lastActivated, mod.activation) >= 0) {
                ApplyModifier(mod);
            }

            if(TimeSpan.Compare(DateTime.Now - mod.started, mod.duration) >= 0) {
                RemoveModifier(mod);
            }
        }
    }

    public void ApplyModifier(ResourceModifer mod) {
        switch (mod.type) {
            case StatModType.Flat:
                currentValue += mod.value;
                break;
            case StatModType.PercentAdd:
                currentValue += baseValue * mod.value;
                break;
            case StatModType.PercentMulti:
                currentValue *= 1 + mod.value;
                break;
            default:
                break;
        }

        if(currentValue >= baseValue) {
            currentValue = baseValue;
        }
    }
}
