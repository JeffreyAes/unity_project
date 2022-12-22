using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class EditorShortCutKeys : ScriptableObject
{

    [MenuItem("Edit/Run _F5")] // shortcut key F5 to Play (and exit playmode also)
    static void PlayGame()
    {
        if (!Application.isPlaying)
        {
            EditorSceneManager.SaveScene(SceneManager.GetActiveScene(), "", false);
        }
        EditorApplication.ExecuteMenuItem("Edit/Play");
    }

    [MenuItem("Pause/Play _F6")] // shortcut key F6 to Pause
    static void PauseGame()
    {
        Debug.Break();
    }


}