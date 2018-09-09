using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarrouselController : MonoBehaviour {
	[Header("Item config")]
	public int visibleAmount = 3;
	public RectTransform[] items;

	[Header("Offset && Color")]
	public float[] padding = {10f, 10f, 10f, 10f};
	public float spacing = 5f;
	public Color highlight = new Color (255f, 255f, 255f, 255f);

	private Vector3 startPosition;
	private int startIndex = 0, endIndex = 0, currentIndex = 0;
	private bool focus = false;
	private Text[] _labels;

	// Use this for initialization
	private void Start () {
		startPosition = transform.position;

		//initialize arrays
		_labels = new Text[items.Length];

		//fill arrays
		for (int i = 0; i < items.Length; i++) {
			items [i] = Instantiate (items [i], this.transform);
			_labels [i] = items [i].GetComponent<Text> ();
		}

		//set endindex
		endIndex = visibleAmount -1;
		ShowItems ();
	}

	private void Update(){
		if (Input.GetKeyDown(KeyCode.UpArrow))
			PreviousItem ();
		else if (Input.GetKeyDown(KeyCode.DownArrow))
			NextItem ();
	}

	public void NextItem(){
		//set current index back to start when end is reached
		if (currentIndex == items.Length - 1) {
			startIndex = 0;
			currentIndex = startIndex;
			endIndex = visibleAmount - 1;
		} else if(currentIndex < endIndex){
			currentIndex++;
		} else {
			startIndex++;
			currentIndex++;
			endIndex++;
		}

		transform.position = startPosition + Vector3.up * ((items [0].sizeDelta.y + spacing) * startIndex);
		ShowItems ();
		return;
	}

	public void PreviousItem(){
		//set current index back to start when end is reached
		if (currentIndex == 0) {
			startIndex = items.Length - visibleAmount;
			endIndex = items.Length -1;
			currentIndex = endIndex;
		} else if (currentIndex > startIndex){
			currentIndex--;
		} else {
			startIndex--;
			currentIndex--;
			endIndex--;
		}

		transform.position = startPosition + Vector3.up * ((items [0].sizeDelta.y + spacing) * startIndex);
		ShowItems ();
		return;
	}

	private void ShowItems(){
		for (int i = 0; i < items.Length; i++) {
			Text lbl = _labels [i];
			if (lbl != null) {
				if (i == currentIndex) lbl.color = highlight;
				else if (i > endIndex || i < startIndex) lbl.color = new Color (0f, 0f, 0f, 255f);
				else lbl.color = new Color (255f, 255f, 255f, 255f);
			}
		}
	}
}
