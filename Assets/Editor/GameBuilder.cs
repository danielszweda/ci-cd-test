using System;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class GameBuilder : MonoBehaviour
{
    [MenuItem("Build/Build Windows")]
    public static void BuildWindows()
    {
        var buildPlayerOptions = new BuildPlayerOptions()
        {
            scenes = new[]{"Assets/Scenes/SampleScene.unity"},
            locationPathName = $"Builds/Windows/vrjam-{GetArg("-buildNumber")}.exe",
            target = BuildTarget.StandaloneWindows64,
            options = BuildOptions.None
        };

        var buildReport = BuildPipeline.BuildPlayer(buildPlayerOptions);
        var summary = buildReport.summary;
        switch (summary.result)
        {
            case BuildResult.Succeeded:
                Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
                break;
            case BuildResult.Failed:
                Debug.LogError("Build Failed");
                break;
            case BuildResult.Unknown:
                Debug.LogError("Build Unknown");
                break;
            case BuildResult.Cancelled:
                Debug.LogWarning("Build Cancelled");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
    }

    public static string GetProjectVersion()
    {
        return Application.version;
    }
    
    private static string GetArg(string name)
    {
        var args = Environment.GetCommandLineArgs();
        for (var i = 0; i < args.Length; i++)
        {
            if (args[i] == name && args.Length > i + 1)
            {
                return args[i + 1];
            }
        }
        return null;
    }
    
}
