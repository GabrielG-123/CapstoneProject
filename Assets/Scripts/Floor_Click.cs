using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Floor_Click : MonoBehaviour
{
    public List<Texture2D> itemTextures = new List<Texture2D>();
    public GameObject itemSlot;
    public GameObject UI_Panel;
    [SerializeField] MenuController menuController;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PopulateTextureGrid();
    }

    // Update is called once per 
    void Update()
    {
        
    }


    private void PopulateTextureGrid()
    {

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
      
        menuController.OpenMenu(); 
        menuController.menuActive = true;
        SelectionManager.Instance.SelectFloorClick(this.gameObject);
        

    }



}
