using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TableController : MonoBehaviour {

    [Range(1, 5)] public int colloms = 1;
    public GameObject tableHeaderPrefab;
    public GameObject tableRowPrefab;
    public GameObject tableItem;

    private List<string[]> TestRows = new List<string[]>();

    private void Start() {
        TestRows.Add(new string[] { "name", "Amount", "type" });
        TestRows.Add(new string[] { "sword", "5", "weapon" });
        TestRows.Add(new string[] { "shield", "2", "armor" });
        TestRows.Add(new string[] { "kane", "200", "equipment" });
        TestRows.Add(new string[] { "chestplate", "1", "armor" });

        UpdateTable();
    }

    public void UpdateTable() {
        //Clear Table
        foreach(Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }

        //add Data
        for(int i = 0; i < TestRows.Count; i++) {
            if (i == 0) {
                //Add header row
                AddRow(tableHeaderPrefab, TestRows[0]);
            } else {
                //Add data row
                AddRow(tableRowPrefab, TestRows[i]);
            }
        } 
    }

    private void AddRow(GameObject prefab, string[] data) {
        Transform row;

        row = Instantiate(prefab, this.transform).transform;
        foreach (string s in data) {
            tableItem.GetComponent<Text>().text = s;
            Instantiate(tableItem, row);
        }
    }

}
