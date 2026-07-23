using UnityEngine;

public class SelectionManager : MonoBehaviour
{

    public static SelectionManager Instance { get; private set; }

    public GameObject selectedWall { get; private set; } // Reference to the currently selected Wall_Click script
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Keep the SelectionManager across scenes
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SelectWallClick(GameObject wall)
    {
        selectedWall = wall;
    }
}
