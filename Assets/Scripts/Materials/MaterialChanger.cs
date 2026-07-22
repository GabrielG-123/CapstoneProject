using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    private Renderer wallRenderer;
    private SurfaceData data;

    void Awake()
    {
        wallRenderer = GetComponentInChildren<Renderer>();
        data = GetComponent<SurfaceData>();
    }

    public void ChangeMaterial(Material newMaterial)
    {
        wallRenderer.material = newMaterial;
        wallRenderer.material.mainTextureScale =
            new Vector2(data.Length, data.Width);
    }

    void Start()
    {
        //Debug.Log($"{name} Length={data.Length} Width={data.Width}");
    }
}