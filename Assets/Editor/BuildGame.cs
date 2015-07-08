using UnityEditor;
using System.Diagnostics;
using UnityEngine;
using System.Collections;

public class ScriptBatch 
{
	[MenuItem("BuildTools/Windows Build")]
	public static void BuildGame ()
	{
		// Get filename.
		string path = EditorUtility.SaveFolderPanel("Choose Location of Built Game", "", "");
		string[] levels = new string[] {"Assets/Scenes/Game.unity"};

		UnityEngine.Debug.Log("Caminho "+path);
		
		// Build player.
		//BuildPipeline.BuildPlayer(levels, path + "/BuiltGame.exe", BuildTarget.StandaloneWindows, BuildOptions.None);
		
		BuildPipeline.BuildPlayer( levels, path + "WebPlayerBuild", BuildTarget.WebPlayer, BuildOptions.None); 
		
		// Copy a file from the project folder to the build folder, alongside the built game.
		FileUtil.CopyFileOrDirectory("Assets/Readme/Teste.doc", path + "/Readme.doc");
		
		// Run the game (Process class from System.Diagnostics).
		Process proc = new Process();
		proc.StartInfo.FileName = path + "/WebPlayerBuild";
		proc.Start();
	}
}
