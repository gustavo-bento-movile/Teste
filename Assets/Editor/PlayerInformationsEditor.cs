using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(PlayerInformations))]
public class PlayerInformationsEditor : Editor 
{
	private string gender;

	public override void OnInspectorGUI()
	{
		PlayerInformations player = (PlayerInformations)target;
		
		EditorGUILayout.LabelField ("Name", player.name);

		gender = player.male ? "Male" : "Female";

		EditorGUILayout.LabelField ("Gender", gender);

		player.stamina = EditorGUILayout.Slider ("Stamina", player.stamina, 1, 10);
		player.speed = EditorGUILayout.Slider ("Speed", player.speed, 1, 10);
	}
}
