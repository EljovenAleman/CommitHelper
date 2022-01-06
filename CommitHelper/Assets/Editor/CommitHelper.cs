using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using System;
using Debug = UnityEngine.Debug;

public class CommitHelper : EditorWindow
{
    string myString = "Inserte su mensaje para commitear";

    [MenuItem("CustomExtensions/CommitHelper")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<CommitHelper>();
    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();

        myString = EditorGUILayout.TextField("Inserte mensaje", myString);

        if(GUILayout.Button("Commit"))
        {
            Commit();
        }

        GUILayout.EndHorizontal();
    }

    private void Commit()
    {
        Debug.Log("Se abre el cmd");

        Process process = Process.Start("cmd.exe");
    }
}
