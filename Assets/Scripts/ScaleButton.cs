using UnityEngine;
using System.Collections;

public class ScaleButton : MonoBehaviour {
	
	private Vector3 initialScale;

	// Use this for initialization
	void Start () {
		initialScale = gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseEnter(){
		float parameter = 1.2f;
		Vector3 newScale = new Vector3(gameObject.transform.localScale.x * parameter, gameObject.transform.localScale.y * parameter, 
		                               gameObject.transform.localScale.z * parameter);
		iTween.ScaleTo(gameObject, iTween.Hash("scale", newScale, "time", 0.5f));
	}
	
	void OnMouseExit(){
		iTween.ScaleTo(gameObject, iTween.Hash("scale", initialScale, "time", 0.5f));
	}

}
