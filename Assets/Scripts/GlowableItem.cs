using UnityEngine;

public class GlowableItem : MonoBehaviour
{
    public Renderer objectRenderer;
    public Color glowColor = Color.yellow;

    private Material mat;
    private Color originalColor;
    private bool canUseBaseColor = false;

    void Start()
    {
        if (objectRenderer == null)
            objectRenderer = GetComponentInChildren<Renderer>();

        if (objectRenderer == null)
        {
            Debug.LogWarning("No Renderer found on " + gameObject.name);
            return;
        }

        mat = objectRenderer.material;

        if (mat.HasProperty("_BaseColor"))
        {
            originalColor = mat.GetColor("_BaseColor");
            canUseBaseColor = true;
        }
        else if (mat.HasProperty("_Color"))
        {
            originalColor = mat.GetColor("_Color");
            canUseBaseColor = true;
        }
        else
        {
            Debug.LogWarning("Material on " + gameObject.name + " has no _BaseColor or _Color property.");
        }

        SetGlow(false);
    }

    public void SetGlow(bool on)
    {
        if (mat == null || !canUseBaseColor) return;

        if (mat.HasProperty("_BaseColor"))
        {
            mat.SetColor("_BaseColor", on ? glowColor : originalColor);
        }
        else if (mat.HasProperty("_Color"))
        {
            mat.SetColor("_Color", on ? glowColor : originalColor);
        }
    }
}