using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class ProgressPayload
{
    public string session_id;
    public string module_id;
    public string scenario_id;
    public int scenario_index;
    public string status;
}

public class APIManager : MonoBehaviour
{
    public string progressUrl = "http://localhost:8000/api/training/progress";

    public void SendScenarioCompleted(string scenarioId, int scenarioIndex)
    {
        StartCoroutine(PostProgress(scenarioId, scenarioIndex));
    }

    private IEnumerator PostProgress(string scenarioId, int scenarioIndex)
    {
        ProgressPayload payload = new ProgressPayload
        {
            session_id = LaunchArgsManager.SessionId,
            module_id = LaunchArgsManager.ModuleId,
            scenario_id = scenarioId,
            scenario_index = scenarioIndex,
            status = "completed"
        };

        string json = JsonUtility.ToJson(payload);

        UnityWebRequest request = new UnityWebRequest(progressUrl, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + LaunchArgsManager.JwtToken);

        Debug.Log("Sending scenario progress: " + json);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Scenario progress sent: " + scenarioId);
        }
        else
        {
            Debug.LogError("Progress send failed: " + request.error);
            Debug.LogError(request.downloadHandler.text);
        }
    }
}