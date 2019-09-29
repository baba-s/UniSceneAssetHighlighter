using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KoganeUnityLib
{
	[InitializeOnLoad]
	internal static class SceneAssetHighlighter
	{
		private static readonly Color COLOR = new Color32( 255, 32, 32, 64 );
		
		static SceneAssetHighlighter()
		{
			EditorApplication.projectWindowItemOnGUI += OnGUI;
		}

		private static void OnGUI( string guid, Rect selectionRect )
		{
			var path = AssetDatabase.GUIDToAssetPath( guid );

			var activeScene = SceneManager.GetActiveScene();
			var filename    = Path.GetFileNameWithoutExtension( path );

			if ( activeScene.name != filename ) return;

			var color = GUI.color;
			GUI.color = COLOR;
			GUI.DrawTexture( selectionRect, EditorGUIUtility.whiteTexture );
			GUI.color = color;
		}
	}
}