using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoreSpeed : Obstacle {

	public float delayFlashing;

	private Color redColor;
	private Color originalColor;

	public void Start(){
		redColor = new Color(1, 0, 0, 1);
		originalColor = new Color(1, 1, 1, 1);
		StartCoroutine(FlashingColor());
	}

	IEnumerator FlashingColor(){
		gameObject.GetComponent<Image>().color = redColor;
		yield return new WaitForSeconds(delayFlashing);
		StartCoroutine(ReturnToOriginalColor());
	}

	IEnumerator ReturnToOriginalColor(){

		gameObject.GetComponent<Image>().color = originalColor;
		yield return new WaitForSeconds(delayFlashing);
		StartCoroutine(FlashingColor());
	}


}
