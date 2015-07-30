using UnityEngine;
using System.Collections;

public class ShareApp : MonoBehaviour {

	protected string subject = "High Score: ";

	public void CallShareApp(){
		string highScore = PlayerPrefs.GetFloat("HighScore").ToString();
		AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");
		currentActivity.Call ("shareText", subject, highScore);
	}
}