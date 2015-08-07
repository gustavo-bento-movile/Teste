using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Share : MonoBehaviour {

	public void OnClick(){ 
		#if UNITY_ANDROID 
		AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentAct = unity.GetStatic<AndroidJavaObject> ("currentActivity");
		currentAct.Call ("shareText", "Palmeiras", "Campeao");
		#endif
	}
}
