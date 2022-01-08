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

        GUILayout.Label("Show status of current version");

        if(GUILayout.Button("Status"))
        {
            ShowStatus();
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Label("Add all changes and commit with a message");

        myString = GUILayout.TextField(myString);

        if(GUILayout.Button("Commit"))
        {
            Commit(myString);
        }
    }

    private void Commit(string myString)
    {
        AddAllChangesForCommit();

        string command = $"commit -m\"{myString}\"";

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            FileName = "git",
            CreateNoWindow = false
        };

        Process process = new Process();

        process.StartInfo = startInfo;

        process.StartInfo.Arguments = command;

        process.Start();

        string result = process.StandardOutput.ReadToEnd().Trim();

        process.WaitForExit();

        Debug.Log(result);
    }

    private void AddAllChangesForCommit()
    {
        string command = "add .";

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            FileName = "git",
            CreateNoWindow = false
        };

        Process process = new Process();

        process.StartInfo = startInfo;

        process.StartInfo.Arguments = command;

        process.Start();
        
        process.WaitForExit();

        
    }

    private void ShowStatus()
    {        
        string command = "status";

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            FileName = "git",
            CreateNoWindow = false
        };
                
        Process process = new Process();

        process.StartInfo = startInfo;

        process.StartInfo.Arguments = command;
        
        process.Start();
        
        string result = process.StandardOutput.ReadToEnd().Trim();

        process.WaitForExit();

        Debug.Log(result);

    }
}
