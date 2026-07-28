using UnityEngine;

public enum SurfaceType
{
    Printed_Wall,
    Framed_Wall,
    Floor,
    Ceiling
}

public class SurfaceData : MonoBehaviour
{
    public string surfaceID;
    public SurfaceType surfaceType;

    [SerializeField] private float area;

    public float Area => area;

    private Vector3 Size;

    void Awake()
    {
        MeshFilter meshFilter = GetComponentInChildren<MeshFilter>();

        if (meshFilter == null)
        {
            Debug.LogError($"{name}: No MeshFilter found.");
            return;
        }

        Mesh mesh = meshFilter.sharedMesh;

        Vector3 size = Vector3.Scale(mesh.bounds.size, transform.lossyScale);
        Size = size;

        float[] dims = { size.x, size.y, size.z };

        System.Array.Sort(dims);

        float width = dims[1];
        float length = dims[2];

        area = length * width;
    }

    public Vector3 getSize() 
    { 
        return Size;
    }

}
