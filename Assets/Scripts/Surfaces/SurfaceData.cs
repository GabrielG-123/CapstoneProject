using UnityEngine;

public enum SurfaceType
{
    Exterior_Wall,
    Interior_Wall,
    Framed_Wall,
    Floor,
    Ceiling
}

public class SurfaceData : MonoBehaviour
{
    public string surfaceID;
    public SurfaceType surfaceType;

    [SerializeField] private float area_sqft;
    [SerializeField] private float length;
    [SerializeField] private float width;

    public float Area_Offset;

    public float Area => area_sqft;
    public float Length => length;
    public float Width => width;

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

        width = dims[1];
        length = dims[2];

        area_sqft = length * width;
        area_sqft *= 10.764f; //convert from sq meters to sqft
        area_sqft -= Area_Offset; //account for large holes in walls like a garage door
    }

    public Vector3 getSize()
    {
        return Size;
    }

}