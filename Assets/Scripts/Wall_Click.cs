using System.Collections.Generic; // Add this using directive for List<T>
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class Wall_Click : MonoBehaviour
{
    public GameObject UI_Panel; // Reference to the UI panel you want to show

    public GameObject itemSlot;

    public GameObject wallReference; // Reference to the wall object

    public List<Texture2D> itemTextures = new List<Texture2D>(); // List of textures for the items

    [SerializeField] MenuController menuController; // Reference to the MenuController script   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (UI_Panel != null) {

            UI_Panel.SetActive(false);
          }

         // Populate the UI panel with item slots and textures
    }


    void Awake() {

        PopulateTextureGrid();


    }

    // Update is called once per frame
    void Update()
    {

    }


    private void PopulateTextureGrid() { 
    
                foreach (Texture2D texture in itemTextures)
                {
                    GameObject newItemSlot = Instantiate(itemSlot, UI_Panel.transform); // Create a new item slot as a child of the UI panel
                    RawImage image = newItemSlot.GetComponent<RawImage>();
                    if (image != null)
                    {
                        image.texture = texture; // Set the texture of the item slot
                    }
                }



    }

    private void OnMouseDown()
    {
        if (UI_Panel != null)
        {
            menuController.UI_Panel = UI_Panel; // Assign the UI panel to the MenuController
            menuController.OpenMenu(); // Call the OpenMenu method in MenuController to show the UI panel
            menuController.menuActive = true;
            SelectionManager.Instance.SelectWallClick(this.gameObject); // Show the UI panel when the wall is clicked
        }
    }
}
