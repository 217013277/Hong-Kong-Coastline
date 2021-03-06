using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Popup : MonoBehaviour
{
	[SerializeField] Button _button1;
	[SerializeField] Button _button2;
	[SerializeField] Text _button1Text;
	[SerializeField] Text _button2Text;
	[SerializeField] Text _popupText;

	public void Init(Transform canvas, string popupMessage, string btn1txt = "Close", string btn2txt = "", Action action = null) {
		_popupText.text = popupMessage;
		_button1Text.text = btn1txt;
		_button2Text.text = btn2txt;

		if (btn2txt == "") {
			_button2.gameObject.SetActive(false);
		}

		transform.SetParent(canvas);
		transform.localScale = Vector3.one;
		GetComponent<RectTransform>().offsetMin = Vector2.zero;
		GetComponent<RectTransform>().offsetMax = Vector2.zero;
        // GetComponent<RectTransform>().sizeDelta = new Vector2(300, 200);

		_button1.onClick.AddListener(() => {
			GameObject.Destroy(this.gameObject);
		});

		_button2.onClick.AddListener(() => {
			action();
			GameObject.Destroy(this.gameObject);
		});

	}
}