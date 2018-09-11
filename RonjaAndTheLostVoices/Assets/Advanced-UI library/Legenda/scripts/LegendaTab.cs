using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LegendaTab : MonoBehaviour {
    [Header("Tab properties")]
    public ElementProperties tabProperties = new ElementProperties();
    public ElementProperties ItemProperties = new ElementProperties();

    private RectTransform legendaTabPrefab;
    private Image[] icons;
    private Text[] labels;

    //Components
    private RectTransform _transform;
    private Image _Image;

    //Controller
    private LegendaController controller;
    private ElementProperties properties;

    public void Start () {
        //retrieve controller
        controller = GetComponentInParent<LegendaController>();

        //get components
        _transform = GetComponent<RectTransform>();
        _Image = GetComponent<Image>();
        
        //get and set properties
        AdvancedUI.SetUIProperties(_transform, tabProperties);

        GameObject go = new GameObject();
        legendaTabPrefab = go.AddComponent<RectTransform>();

        icons = new Image[controller.Amount];
        labels = new Text[controller.Amount];

        Initialize();
	}

    public void Initialize() {
        for (int i = 0; i < controller.Amount; i++) {
            //create item
            RectTransform item = Instantiate(legendaTabPrefab, this.transform);

            //set position of item
            SetItemPosition(item, i);

            //set icons
            icons[i] = item.GetComponentInChildren<Image>();
            icons[i].sprite = controller.items[i].icon;

            //set text
            labels[i] = item.GetComponentInChildren<Text>();
            labels[i].text = controller.items[i].name;
        }
    }

    private void SetItemPosition(RectTransform itemTransform, int order) {

        Vector3 position = new Vector3(
            0, 
            -properties.padding.top - (legendaTabPrefab.sizeDelta.y * order) - (properties.spacing * order), 
            0
        );

        itemTransform.anchoredPosition = position;
        itemTransform.offsetMin = new Vector2(properties.padding.left, itemTransform.offsetMin.y);
        itemTransform.offsetMax = new Vector2(-properties.padding.right, itemTransform.offsetMax.y);
    }

    public void SetSize(float size) {
        _transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
    }
}
