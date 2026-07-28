using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    private Renderer wallRenderer;
    private SurfaceData data;

    public float legnthScale = 0.5f;
    public float widthScale = 0.5f;

    void Awake()
    {
        wallRenderer = GetComponentInChildren<Renderer>();
        data = GetComponent<SurfaceData>();
    }

    public void ChangeMaterial(Material newMaterial)
    {
        wallRenderer.material = newMaterial;
        if (data.Length == data.getHeight())
        {
            wallRenderer.material.mainTextureScale =
                new Vector2(data.Width * widthScale, data.Length * legnthScale);
        }
        else
        {
            wallRenderer.material.mainTextureScale =
                new Vector2(data.Length * legnthScale, data.Width * widthScale);
        }
    }

    void Start()
    {
        //Debug.Log($"{name} Length={data.Length} Width={data.Width}");
        ChangeMaterial(wallRenderer.material);
    }
}