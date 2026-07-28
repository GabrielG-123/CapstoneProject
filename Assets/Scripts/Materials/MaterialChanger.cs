using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    private Renderer wallRenderer;
    private SurfaceData data;

    public float xScale = 0.5f;
    public float yScale = 0.5f;

    void Awake()
    {
        wallRenderer = GetComponentInChildren<Renderer>();
        data = GetComponent<SurfaceData>();
    }

    public void ChangeMaterial(Material newMaterial)
    {
        wallRenderer.material = newMaterial;
        Vector3 size = data.getSize();

        float[] dims = { size.x, size.y, size.z };

        System.Array.Sort(dims);

        if (dims[0] == size.x)
        {
            wallRenderer.material.mainTextureScale =
                new Vector2(size.z * xScale, size.y * yScale);
        }
        else if (dims[0] == size.y)
        {
            wallRenderer.material.mainTextureScale =
                new Vector2(size.x * xScale, size.z * yScale);
        }
        else if (dims[0] == size.z)
        {
            wallRenderer.material.mainTextureScale =
                new Vector2(size.x * xScale, size.y * yScale);
        }
    }

    void Start()
    {
        //Vector3 size = data.getSize();
        //Debug.Log($"{name} x={size.x} y={size.y} z={size.z}");
        ChangeMaterial(wallRenderer.material);
    }
}