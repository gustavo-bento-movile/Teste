using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour 
{
	public bool allow;
	public GameController gameController;

	private Vector3 ObjectPosition;
	private Animator animator;
	private float animationTime = 0.8f;

	private float initialTime;

	void Start()
	{
		animator = gameObject.GetComponent<Animator> ();
	}

	void Update () 
	{
		if (allow)
		{
			if (Input.GetKey (KeyCode.UpArrow)) 
			{
				animator.SetTrigger ("Jump");
				allow = false;
				initialTime = Time.time;

			} 
			else if (Input.GetKey (KeyCode.DownArrow)) 
			{
				animator.SetTrigger ("Low");
				allow = false;
				initialTime = Time.time;
			}
		}

		if(Time.time - initialTime > animationTime)
		{
			allow = true;
		}
		
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "SpeedBonus")
		{
			gameController.IncreaseGameSpeed(true);
			GameObject.Destroy(coll.gameObject);
		}
		else
		{
			gameController.PlayerDie ();
		}

	}

}
