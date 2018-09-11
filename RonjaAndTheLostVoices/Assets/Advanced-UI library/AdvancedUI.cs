using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class AdvancedUI {

	public static void SetUIProperties(RectTransform element, ElementProperties properties) {
        #region Layout and position
        element.anchorMin = properties.anchors.Min;
        element.anchorMax = properties.anchors.Max;

        element.pivot = properties.pivot;

        element.offsetMin = properties.padding.OffsetMin;
        element.offsetMax = properties.padding.OffsetMax;

        #endregion

        #region image properties
        Image image = element.GetComponent<Image>();
        if(image != null) {
            image.color = properties.BackgroundColor;
        }
        #endregion

        #region Text properties
        Text text = element.GetComponent<Text>();
        if(text != null) {
            text.color = properties.TextColor;
            text.font = properties.Font;
        }
        #endregion
    }
}
