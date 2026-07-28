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

    [SerializeField] private float length;
    [SerializeField] private float width;
    [SerializeField] private float area;

    private float height;

    public float Length => length;
    public float Width => width;
    public float Area => area;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

        float[] dims = { size.x, size.y, size.z };
        height = size.y;

        System.Array.Sort(dims);

        width = dims[1];//Mathf.Round(dims[1]);
        length = dims[2];// Mathf.Round(dims[2]);

        area = length * width;
    }

    public float getHeight()
    {
        return height;
    }

}
