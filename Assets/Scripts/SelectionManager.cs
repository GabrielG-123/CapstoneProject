using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class SelectionManager : MonoBehaviour
{

    public static SelectionManager Instance { get; private set; }

    //public GameObject selectedWall { get; private set; }
    //public GameObject selectedFloor { get; private set; }

    public GameObject selectedSurface;
    public Material smoothFinish;

    public float takeOff;
    public SurfaceData[] surfaces;
    public List<SurfaceData> printedWalls = new List<SurfaceData>();

    public TMP_Text takeoffText;

    //public bool wallClicked;
    //public bool floorClicked;



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

    /*
    public void SelectWallClick(GameObject wall)
    {
        selectedWall = wall;
    }

    public void SelectFloorClick(GameObject floor) { 
    
        
        selectedFloor = floor;
    
    }
    */
}
