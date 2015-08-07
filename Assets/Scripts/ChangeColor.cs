using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour {
	Color originalColor;

	void Start(){
		originalColor = gameObject.GetComponent<Image>().color;
	}

	public void changeColor(string color){
		Debug.Log("ChangeColor");
		if(color.Equals("white")){
			gameObject.GetComponent<Image>().color = Color.white;
			Debug.Log("White");
		}
		else if(color.Equals("green")){
			gameObject.GetComponent<Image>().color = Color.green;
			Debug.Log("Green");
		}
		else if(color.Equals("original")){
			gameObject.GetComponent<Image>().color = originalColor;
			Debug.Log("Original");
		}
	}
}
