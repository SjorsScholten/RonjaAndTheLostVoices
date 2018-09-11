using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LegendaTab))]
[RequireComponent(typeof(LegendaContent))]
public class LegendaController : MonoBehaviour {
    [Header("Legenda content")]
    public LegendaItem[] items;
    private int currentTab = 0;

    [Header("Legenda properties")]
    public KeyCode openMenuButton = KeyCode.M;
    public float sizeClosed = 45f;
    public float sizeOpen = 200f;
    private bool open = true;

    

    private LegendaTab tab;
    private LegendaContent content;


    private void Start() {
        tab = GetComponentInChildren<LegendaTab>();
        content = GetComponentInChildren<LegendaContent>();
    }

    private void Update() {
        if (Input.GetKeyDown(openMenuButton)) OpenClose();
    }

    private void OpenClose() {
        float size = 0;
        open = !open;

        if (open) size = sizeOpen;
        else size = sizeClosed;

        tab.SetSize(size);
        content.SetSize(size);
    }

    public int Amount {
        get { return items.Length; }
    }

    public int CurrentTab {
        get { return currentTab; }
        set { currentTab = value; }
    }
}
