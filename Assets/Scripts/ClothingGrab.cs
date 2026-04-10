using UnityEngine;

public class ClothingGrab : MonoBehaviour
{
    public LockerBubble lockerBubble;
    public GlowableItem glowItem;
    public PPEScenarioManager ppeScenarioManager;

    public string itemName = "shirt";

    private bool hasBeenGrabbed = false;

    public void OnGrabbed()
    {
        if (hasBeenGrabbed) return;
        hasBeenGrabbed = true;

        if (lockerBubble != null)
        {
            lockerBubble.ItemGrabbed(glowItem);
        }

        if (ppeScenarioManager != null)
        {
            ppeScenarioManager.MarkItemCollected(itemName);
        }
        else
        {
            Debug.LogWarning("PPEScenarioManager not assigned!");
        }

        gameObject.SetActive(false);
    }
}