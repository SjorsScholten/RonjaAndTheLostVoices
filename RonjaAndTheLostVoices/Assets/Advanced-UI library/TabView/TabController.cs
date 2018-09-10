using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabController : MonoBehaviour {
    public Color neutralColor = Color.black;
    public Color highlightColor = Color.green;

    public string[] tabNames = {"Tab_1", "Tab_2", "Tab_3" } ;
    public GameObject[] tabContents;

    public RectTransform tabPrefab;
    public RectTransform tabHolder;
    public RectTransform contentHolder;

    private int currentTabIndex = 0;

	void Start () {
        //Create tabs
        for (int i = 0; i < tabNames.Length; i++) {
            Instantiate(tabPrefab, tabHolder);
            Instantiate(tabContents[i], contentHolder).SetActive(false);
        }

        //Set tab text
        Text[] tabs = tabHolder.GetComponentsInChildren<Text>();
        for (int i = 0; i < tabs.Length; i++) {
            tabs[i].text = tabNames[i];
        }

        ShowTab();
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) NextTab();
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) PreviousTab();
    }

    private void NextTab() {
        currentTabIndex++;
        if(currentTabIndex >= tabNames.Length) {
            currentTabIndex = 0;
        }

        ShowTab();
    }

    private void PreviousTab() {
        currentTabIndex--;
        if(currentTabIndex < 0) {
            currentTabIndex = tabNames.Length - 1;
        }

        ShowTab();
    }

    public void ShowTab() {
        for (int i = 0; i < contentHolder.childCount; i++) {
            Transform tabContent = contentHolder.GetChild(i);
            Transform tabHeader = tabHolder.GetChild(i);
            if(i == currentTabIndex) {
                tabContent.gameObject.SetActive(true);
                tabHeader.GetComponent<Image>().color = highlightColor;
            } else {
                tabContent.gameObject.SetActive(false);
                tabHeader.GetComponent<Image>().color = neutralColor;
            }
        }
    }
}
