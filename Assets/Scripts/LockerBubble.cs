using UnityEngine;
using TMPro;

public class LockerBubble : MonoBehaviour
{
    public TextMeshProUGUI textUI;

    [TextArea(3, 8)]
    public string[] pages;

    public GlowableItem[] pageItems; // item linked to each page

    private int currentPage = 0;
    private bool waitingForGrab = true;

    void Start()
    {
        ShowPage();
    }

    void ShowPage()
    {
        textUI.text = pages[currentPage];

        // turn off all glows first
        foreach (GlowableItem item in pageItems)
        {
            if (item != null)
                item.SetGlow(false);
        }

        // glow current required item
        if (currentPage < pageItems.Length && pageItems[currentPage] != null)
        {
            pageItems[currentPage].SetGlow(true);
            waitingForGrab = true;
        }
        else
        {
            waitingForGrab = false;
        }
    }

    public void ItemGrabbed(GlowableItem grabbedItem)
    {
        if (currentPage < pageItems.Length && grabbedItem == pageItems[currentPage])
        {
            grabbedItem.SetGlow(false);
            grabbedItem.gameObject.SetActive(false);

            waitingForGrab = false;
            NextPage();
        }
    }

    public void NextPage()
    {
        if (waitingForGrab) return;

        if (currentPage < pages.Length - 1)
        {
            currentPage++;
            ShowPage();
        }
    }
}