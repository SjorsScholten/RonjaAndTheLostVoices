using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Legenda Item", menuName = "Advanced-UI/Legenda item", order = 1)]
public class LegendaItem : ScriptableObject {
    new public string name = "default_name";
    public Sprite icon;
    public LegendaItemContent[] content;
}

public enum LegendaItemContentType {None, Paragraph, Image }

[System.Serializable]
public class LegendaItemContent {
    public LegendaItemContentType type = LegendaItemContentType.None;
    [TextArea()]public string text = "default text";
    public Sprite image;
}
