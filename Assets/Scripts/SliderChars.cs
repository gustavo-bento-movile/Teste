using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderChars : MonoBehaviour {

	public GameObject chars;
	public float[] position;
	public ScrollRect descriptionScroll;
	public RectTransform[] text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnSlide(float value){
		Debug.Log("Valor: " + value);
		iTween.MoveTo(chars, iTween.Hash("x", position[(int)value], "time", 0.4f, "isLocal", true)); 
		descriptionScroll.content = text[(int)value];

		DisabledTexts();
		text[(int)value].gameObject.SetActive(true);
	}

	protected void DisabledTexts (){
		foreach(var temp in text){
			temp.gameObject.SetActive(false);
		}
	}
}
