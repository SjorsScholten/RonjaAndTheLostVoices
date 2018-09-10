using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LegendaTab : MonoBehaviour {
    [Header("Item properties")]
    public RectTransform itemPrefab;
    public LegendaItem[] items;
    private Image[] icons;
    private Text[] labels;

    [Header("Legenda properties")]
    public bool open = true;
    public float sizeClosed = 45f;
    public float sizeOpen = 200f;
    public float spacing = 2f;
    public Padding padding;

    private RectTransform _transform;

    
	void Start () {
        _transform = GetComponent<RectTransform>();
        OpenClose();

        icons = new Image[items.Length];
        labels = new Text[items.Length];

        for (int i = 0; i < items.Length; i++) {

            //create item
            RectTransform item = Instantiate(itemPrefab, this.transform);

            //set position of item
            Vector3 position = new Vector3(0, -padding.top - (itemPrefab.sizeDelta.y * i) - (2 * i), 0);
            item.anchoredPosition = position;
            item.offsetMin = new Vector2(padding.left, item.offsetMin.y);
            item.offsetMax = new Vector2(-padding.right, item.offsetMax.y);

            //set icons
            icons[i] = item.GetComponentInChildren<Image>();
            icons[i].sprite = items[i].icon;

            //set text
            labels[i] = item.GetComponentInChildren<Text>();
            labels[i].text = items[i].name;
        }
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) OpenClose();
	}

    private void OpenClose() {
        open = !open;
        if (open) _transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, sizeOpen);
        else _transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, sizeClosed);
        //Mathf.Lerp()
    }
}
