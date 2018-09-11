using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ElementProperties {
    [Header("Layout")]
    public Padding padding;
    public Anchor anchors;
    public Vector2 pivot;
    public float spacing = 2f;

    [Header("Color")]
    public Color BackgroundColor = new Color(255f, 255f, 255f, 255f);
    public Color TextColor = new Color(255f, 255f, 255f, 255f);
    public Font Font;
}
