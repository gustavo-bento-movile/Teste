using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class CreateChar : EditorWindow
{

	float stamina = 1;
	bool male;
	string name;
	float speed;

	[MenuItem ("Window/Create Char")]
	static void Init()
	{

		CreateChar window = (CreateChar)EditorWindow.GetWindow (typeof (CreateChar));
		window.Show();

	}

	void OnGUI () 
	{
		GUILayout.Label ("Base Settings", EditorStyles.boldLabel);
		
		name = EditorGUILayout.TextField ("Name", name);
		male = EditorGUILayout.Toggle ("Male", male);
		stamina = EditorGUILayout.Slider ("Stamina", stamina, 1, 10);
		speed = EditorGUILayout.Slider ("Speed", speed, 1, 10);

		if (GUILayout.Button ("Create")) 
		{
			Create();
		}
	}

	void Create()
	{
		GameObject player = new GameObject ();
		player.name = name;

		player.AddComponent<CanvasRenderer> ();
		player.AddComponent<Image> ();
		player.AddComponent<PlayerInformations> ();

		PlayerInformations constructor = player.GetComponent<PlayerInformations> ();
		constructor.name = name;
		constructor.stamina = stamina;
		constructor.speed = speed;
		constructor.male = male;

	}


}
