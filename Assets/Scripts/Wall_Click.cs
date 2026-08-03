using System.Collections.Generic; // Add this using directive for List<T>
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class Wall_Click : MonoBehaviour
{
  //  public GameObject UI_Panel; // Reference to the UI panel you want to show

    public GameObject ThreeDSelectionPanel; // Reference to the 3D selection panel

    public GameObject itemSlot;

    public GameObject wallReference; // Reference to the wall object

    public List<Texture2D> itemTextures = new List<Texture2D>(); // List of textures for the items

    [SerializeField] MenuController menuController; // Reference to the MenuController script   

    public bool is3DPrintedWall = false; // Flag to indicate if the wall is a 3D printed wall

    public Renderer wallRenderer;
    public Material smoothFinish;
    public Material threeDPrintedFinish;

    public MaterialChanger wall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //if (UI_Panel != null) {

        //    UI_Panel.SetActive(false);
        //  }

        // Populate the UI panel with item slots and textures

        wallRenderer = gameObject.GetComponent<Renderer>();


    }


    void Awake()
    {

      //  PopulateTextureGrid();
        wall = GetComponent<MaterialChanger>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    //private void PopulateTextureGrid()
    //{

    //    foreach (Texture2D texture in itemTextures)
    //    {
    //        GameObject newItemSlot = Instantiate(itemSlot, UI_Panel.transform); // Create a new item slot as a child of the UI panel
    //        RawImage image = newItemSlot.GetComponent<RawImage>();
    //        if (image != null)
    //        {
    //            image.texture = texture; // Set the texture of the item slot
    //        }
    //    }



    //}


    //public void SmoothFinishClick()
    //{

    //    if (wall == null) wallRenderer.material = smoothFinish;
    //    else wall.ChangeMaterial(smoothFinish);

    //    Debug.Log("Smooth finish applied to wall: " + gameObject.name);



    //}


    //public void ExposedFinishClick()
    //{


    //    if (wall == null) wallRenderer.material = threeDPrintedFinish;
    //    else wall.ChangeMaterial(threeDPrintedFinish);


    //}

    private void OnMouseDown()
    {
        //if (UI_Panel != null)
        //{
        //    menuController.UI_Panel = UI_Panel; // Assign the UI panel to the MenuController
        //    menuController.OpenMenu(); // Call the OpenMenu method in MenuController to show the UI panel
        //    menuController.menuActive = true;
        //    SelectionManager.Instance.SelectWallClick(this.gameObject); // Show the UI panel when the wall is clicked
        //}




        // Check if the wall is a 3D printed wall and toggle the flag
        if (gameObject.CompareTag("3DPrinted"))
        {
            SelectionManager.Instance.wallClicked = true;
            ThreeDSelectionPanel.SetActive(true);
            menuController.OpenMenu();
            menuController.menuActive = true;
            
            SelectionManager.Instance.SelectWallClick(this.gameObject); // Show the 3D selection panel when the wall is clicked
            // SelectionManager.Instance.SelectWallClick(this.gameObject); // Show the 3D selection panel when the wall is clicked



        }
    }

}