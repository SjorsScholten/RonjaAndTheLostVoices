using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LegendaContent : MonoBehaviour {
    [Header("Content properties")]
    public ElementProperties contentProperties = new ElementProperties();

    [Header("Item properties")]
    public RectTransform legendaContentPrefab;

    [Header("Item layout")]
    public Padding padding;

    private RectTransform _transform;
    private LegendaController controller;

    void Start () {
        _transform = GetComponent<RectTransform>();
        controller = GetComponentInParent<LegendaController>();

        Initialize();
    }

    private void Initialize() {
        for (int i = 0; i < controller.Amount; i++) {
            RectTransform item = Instantiate(legendaContentPrefab, this.transform);

            SetItemPosition(item);

            LegendaItemContent[] itemContent = controller.items[i].content;
            for (int x = 0; x < itemContent.Length; x++) {
                GameObject content = new GameObject();
                content.AddComponent<RectTransform>();
                content.transform.SetParent(this.transform);
                
                switch (itemContent[x].type) {
                    case LegendaItemContentType.None:
                        //add no component
                        break;
                    case LegendaItemContentType.Paragraph:
                        Text text = content.gameObject.AddComponent<Text>();
                        text.text = itemContent[x].text;
                        break;
                    case LegendaItemContentType.Image:
                        Image image = content.gameObject.AddComponent<Image>();
                        image.sprite = itemContent[x].image;
                        break;
                    default:
                        //add no component
                        break;
                }
            }
        }

        ShowContent(controller.CurrentTab);
    }

    public void ShowContent(int index) {
        if (index == controller.CurrentTab) return;

        _transform.GetChild(controller.CurrentTab).gameObject.SetActive(false);
        _transform.GetChild(index).gameObject.SetActive(true);
        controller.CurrentTab = index;
    }

    private void SetItemPosition(RectTransform itemTransform) {
        itemTransform.offsetMin = new Vector2(padding.left, padding.top);
        itemTransform.offsetMax = new Vector2(-padding.right, -padding.bottom);
    }

    public void SetSize(float size) {
        _transform.offsetMin = new Vector2(size, _transform.offsetMin.y);
    }
}
