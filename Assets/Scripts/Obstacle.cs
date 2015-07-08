using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	[HideInInspector]
	public bool allowCreate;

	[HideInInspector]
	public float initialTime;

	public Transform player;
	public float delta;
	public float timeToDestroyObject;
	private bool firstTime = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!allowCreate && Time.time - initialTime > delta) 
		{
			allowCreate = true;
		}

		Vector3 forward = new Vector3(6970,0,0);
		Vector3 toOther = player.position - transform.position;

		if (!firstTime && Vector3.Dot(forward, toOther) > 0){
			GameController.numberObstacleCrossed++;
			Debug.Log (GameController.numberObstacleCrossed);
			firstTime = true;
		}

	}

	public void DestroyObject()
	{
		StartCoroutine (AuxDestroyObject());
	}

	IEnumerator AuxDestroyObject()
	{
		yield return new WaitForSeconds (timeToDestroyObject);
		GameObject.Destroy (gameObject);
	}
}
