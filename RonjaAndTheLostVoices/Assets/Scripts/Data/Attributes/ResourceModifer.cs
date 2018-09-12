using System;
using System.Collections;
using System.Collections.Generic;

public class ResourceModifer : StatModifier {
    public readonly TimeSpan duration;
    public readonly TimeSpan activation;
    public readonly DateTime started;
    public readonly DateTime lastActivated;

    public ResourceModifer(float value, StatModType type, TimeSpan duration, TimeSpan activation) : base (value, type) {
        this.duration = duration;
        this.activation = activation;
    }

    public ResourceModifer(float value, StatModType type) : this(value, type, TimeSpan.Zero, TimeSpan.Zero) { }
}
