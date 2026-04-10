using System;
using UnityEngine;

public class LaunchArgsManager : MonoBehaviour
{
    public static string JwtToken;
    public static string SessionId;
    public static string ModuleId;
    public static string ScenarioId;

    void Awake()
    {
        string[] args = Environment.GetCommandLineArgs();

        foreach (string arg in args)
        {
            if (arg.StartsWith("--token="))
                JwtToken = arg.Substring("--token=".Length);

            else if (arg.StartsWith("--session="))
                SessionId = arg.Substring("--session=".Length);

            else if (arg.StartsWith("--module_id="))
                ModuleId = arg.Substring("--module_id=".Length);

            else if (arg.StartsWith("--scenario_id="))
                ScenarioId = arg.Substring("--scenario_id=".Length);
        }

        Debug.Log("JWT: " + JwtToken);
        Debug.Log("Session: " + SessionId);
        Debug.Log("Module: " + ModuleId);
        Debug.Log("Scenario: " + ScenarioId);
    }
}