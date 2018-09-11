using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Padding {
    public float left;
    public float right;
    public float top;
    public float bottom;

    public Vector2 OffsetMin {
        get { return new Vector2(left, top); }
    }

    public Vector2 OffsetMax {
        get { return new Vector2(-right, -bottom); }
    }
}
