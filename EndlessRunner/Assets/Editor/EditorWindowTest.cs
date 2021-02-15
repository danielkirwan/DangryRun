using UnityEngine;
using UnityEditor;

public class EditorWindowTest : EditorWindow
{
    private float scale;

    [MenuItem("Window/EditorTest")]
   public static void OpenWindow()
    {
        GetWindow<EditorWindowTest>("Editor Test");
    }

    private void OnGUI()
    {
        

        GUILayout.Label("Welcome to the editor window", EditorStyles.boldLabel);

        if(GUILayout.Button("Apply random rotation"))
        {
            foreach(var selectedObject in Selection.gameObjects)
            {
                selectedObject.transform.rotation = Quaternion.Euler(Random.Range(-360f, 360f), Random.Range(-360f, 360f), Random.Range(-360f, 360f));
            }
        }

        scale = EditorGUILayout.FloatField("Scale", scale);

        if(GUILayout.Button("Apply scale "))
        {
            foreach (var selectedObject in Selection.gameObjects)
            {
                selectedObject.transform.localScale = Vector3.one * scale;
            }
        }

    }
}
