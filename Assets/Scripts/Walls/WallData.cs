using UnityEngine;

public class WallData : MonoBehaviour
{
    public string wallID;

    private float length;
    private float height;
    private float depth;
    private float Area;

    void Awake()
    {
        // Get the MeshRenderer component attached to the cube
        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();

        if (meshRenderer != null)
        {
            // Get the world-space bounding box size
            Vector3 size = meshRenderer.bounds.size;

            length = Mathf.Max(size.x, size.z);
            height = size.y; // Height (along Y-axis)
            depth = Mathf.Min(size.x,size.z);

            Area = length * height;

            //Debug.Log($"Length: {length}, Height: {height}, Depth: {depth}");
        }
    }

    public float GetArea()
    {
        return Area;
    }
}