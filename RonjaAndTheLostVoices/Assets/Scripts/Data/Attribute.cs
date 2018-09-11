using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute {
    public readonly string name = "default attribute";
    private float value = 10f;

    public Attribute(string name, float value) {
        this.name = name;
        this.value = value;
    }

    public float Value {
        get { return value; }
    }
}
