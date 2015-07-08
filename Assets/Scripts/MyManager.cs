using UnityEngine;
using System.Collections;

public class MyManager : MonoBehaviour {

	private bool ballClicked = true;
	private bool firstPerson = false;

	public GameObject windowCharDescription;
	public GameObject windowGame;
	public GameObject charCanvas;
	public GameObject firstPersonObject;

	private Vector3 windowCharDescriptionScale;
	private Vector3 windowGameScale;
	private Vector3 leftPosition;
	private Vector3 rightPosition;

	// Use this for initialization
	void Start () {

		windowCharDescriptionScale = windowCharDescription.transform.localScale;
		windowGameScale = windowGame.transform.localScale;
		leftPosition = windowCharDescription.transform.position;
		rightPosition = windowGame.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnCharDescriptionClicked(){
		ballClicked = false;
		CloseWindowToBall(windowCharDescription);
		CloseWindowToBall(windowGame);
		charCanvas.SetActive(true);
	}

	public void OnMouseUp(){
		ballClicked = !ballClicked;
		charCanvas.SetActive(false);

		if(ballClicked){
			OpenWindowFromBall(windowCharDescription, windowCharDescriptionScale, leftPosition);
			OpenWindowFromBall(windowGame, windowGameScale, rightPosition);
		}
		else{
			CloseWindowToBall(windowCharDescription);
			CloseWindowToBall(windowGame);
		}
	}

	void OpenWindowFromBall(GameObject myObject, Vector3 myScale, Vector3 myPosition){
		Debug.Log ("Teste");
		iTween.ScaleTo(myObject, myScale, 0.8f);
		iTween.MoveTo (myObject, myPosition, 0.8f);
	}

	void CloseWindowToBall(GameObject myObject){
		iTween.ScaleTo(myObject, Vector3.zero, 0.5f);
		iTween.MoveTo (myObject, gameObject.transform.position, 0.5f);
	}

	public void OnFirstPersonClicked(){
		firstPerson = !firstPerson;
		if(firstPerson){
			firstPersonObject.SetActive(true);
			GameObject.Destroy(gameObject.transform.parent.parent);
		}
		else{
			Application.LoadLevel("Initial Scene");
		}
	}
}
