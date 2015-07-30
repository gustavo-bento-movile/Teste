using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Transform startMarker;
	public Transform endMarker;
	public float speedOfDistance = 1.0F;
	public Text distance;
 	private float startTime;
	private float journeyLength;

	public Button startButton;	
	public float timeBetweenMissiles;
	public Animator[] animations;
	public Animator playerAnimator;
	public GameObject panel;
	public GameObject[] missile;
	public bool allowObstacle;
	public int divisor;
	public int minNumber;
	public int maxNumber;
	public int delta;
	public Text highScore; 

	private bool canIncreaseSpeed = false;
	private bool die;
	private bool changedDifficulty;
	private GameObject canvas;
	private float initialTime;
	private bool shot;

	public static int numberObstacleCrossed = 0;

	void Start () 
	{
		StartButton();

		if(PlayerPrefs.GetInt("ExistHighScore") == 1)
		{
			highScore.text = PlayerPrefs.GetFloat("HighScore").ToString();
		}

		Time.timeScale = 0;
		canvas = GameObject.FindGameObjectWithTag("MainCanvas");
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!shot) 
		{
			ObstacleProperties();
		}
		else if (Time.time - initialTime > timeBetweenMissiles) 
		{
			shot = false;
		}

		/*
		 * IncreaseSpeedVerification();
		if(canIncreaseSpeed)
		{
			canIncreaseSpeed = false;
			IncreaseGameSpeed(false);
		}
		 */

		Distance ();

		if(!changedDifficulty)Difficulty ();
		
	}

	void IncreaseSpeedVerification()
	{
		int temp = (int) float.Parse (distance.text);

		switch(temp)
		{
			case 20:
			case 30:
			case 50:
				canIncreaseSpeed = true;
				break;
		}
	}

	void ObstacleProperties()
	{
		foreach (GameObject obstacle in missile) 
		{
			if (obstacle.GetComponent<Obstacle> ().allowCreate) 
			{
				if(!shot)
				{
					RandomInstantiateObstacle (obstacle);
				}

				obstacle.GetComponent<Obstacle> ().initialTime = Time.time;
				obstacle.GetComponent<Obstacle> ().allowCreate = false;
			}
		}
	}

	void Distance()
	{
		float distCovered = (Time.time - startTime) * speedOfDistance;
		float fracJourney = distCovered / journeyLength;
		
		if (!die) 
		{
			distance.text = ((Vector3.Lerp (startMarker.position, endMarker.position, fracJourney).x - 20)).ToString ("0.0");
		}
	}

	
	public void Difficulty ()
	{
		if (float.Parse (distance.text) != 0 && float.Parse (distance.text) % 10 == 0) 
		{
			changedDifficulty = true;
			timeBetweenMissiles /= 2;
		}
	}

	void RandomInstantiateObstacle(GameObject obstacle)
	{
		int aux = Random.Range(minNumber, maxNumber);
		if(aux % divisor == 0)
		{
			changedDifficulty = false;
			shot = true;
			initialTime = Time.time;
			GameObject missileClone = Instantiate(obstacle) as GameObject;
			missileClone.GetComponent<Animator>().enabled = true;
			missileClone.transform.SetParent(canvas.transform);
			missileClone.GetComponent<Obstacle>().DestroyObject();
		}
	}

	public void StartGame()
	{
		GameObject.Destroy (panel);
		Time.timeScale = 1;
	}

	public void PlayerDie()
	{
		die = true;

		foreach (Animator anim in animations) 
		{
			anim.speed = 0;
		}
		
		if(float.Parse (distance.text) > PlayerPrefs.GetFloat("HighScore"))
		{
			PlayerPrefs.SetFloat("HighScore", float.Parse (distance.text));
			PlayerPrefs.SetInt("ExistHighScore", 1);
		}

		playerAnimator.SetBool ("Die", true);
		StartCoroutine(ReloadScene ());
	}

	IEnumerator ReloadScene()
	{
		yield return new WaitForSeconds (1.2f);
		Application.LoadLevel ("Game 1");
	}

	public void IncreaseGameSpeed(bool timeToFinish)
	{
		Time.timeScale *= 1.3f;
		speedOfDistance *= 1.3f;

		if(timeToFinish)
		{
			StartCoroutine(AuxIncreaseGameSpeed());
	
		}
	}
	protected IEnumerator AuxIncreaseGameSpeed()
	{
		yield return new WaitForSeconds(7);
		Time.timeScale /= 1.3f;
		speedOfDistance /= 1.3f;
	}

	private void StartButton(){
		startButton.onClick.AddListener(() => StartGame());
	}


}
