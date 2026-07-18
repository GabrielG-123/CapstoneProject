using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    private Renderer wallRenderer;

    void Awake()
    {
        wallRenderer = GetComponentInChildren<Renderer>();
    }

    public void ChangeMaterial(Material newMaterial)
    {
        wallRenderer.material = newMaterial;
    }
}