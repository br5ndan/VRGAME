using UnityEngine;

public class PPEScenarioManager : MonoBehaviour
{
    public APIManager apiManager;

    public string scenarioId = "ppe_locker";
    public int scenarioIndex = 0;

    public bool shirtCollected = false;
    public bool pantsCollected = false;
    public bool glovesCollected = false;
    public bool helmetCollected = false;
    public bool bootsCollected = false;
    public bool earplugsCollected = false;

    private bool scenarioCompleted = false;

    public void MarkItemCollected(string itemName)
    {
        switch (itemName)
        {
            case "shirt":
                shirtCollected = true;
                break;
            case "pants":
                pantsCollected = true;
                break;
            case "gloves":
                glovesCollected = true;
                break;
            case "helmet":
                helmetCollected = true;
                break;
            case "boots":
                bootsCollected = true;
                break;
            case "earplugs":
                earplugsCollected = true;
                break;
            default:
                Debug.LogWarning("Unknown PPE item: " + itemName);
                break;
        }

        CheckScenarioCompletion();
    }

    private void CheckScenarioCompletion()
    {
        if (scenarioCompleted) return;

        if (shirtCollected &&
            pantsCollected &&
            glovesCollected &&
            helmetCollected &&
            bootsCollected &&
            earplugsCollected)
        {
            scenarioCompleted = true;
            Debug.Log("PPE scenario complete!");

            if (apiManager != null)
            {
                apiManager.SendScenarioCompleted(scenarioId, scenarioIndex);
            }
            else
            {
                Debug.LogWarning("APIManager not assigned on PPEScenarioManager");
            }
        }
    }
}