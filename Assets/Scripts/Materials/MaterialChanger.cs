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

    void Start() 
    {
        //Debug.Log($"Height: {data.getHeight()}\n Length: {data.getLength()}");

        wallRenderer.material.mainTextureScale = new Vector2(data.Length, data.Width);
    }

    public void ChangeMaterial(Material newMaterial)
    {   
        wallRenderer.material = newMaterial;
    }
}