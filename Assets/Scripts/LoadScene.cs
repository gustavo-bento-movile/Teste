using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

	public string scene;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		Application.LoadLevel(scene);
	}

}
