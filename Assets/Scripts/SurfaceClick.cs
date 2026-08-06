using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class SurfaceClick : MonoBehaviour
{
    public List<Material> printedWallMaterials = new List<Material>();
    public List<Material> floorMaterials = new List<Material>();
    public GameObject itemSlot;
    public GameObject UI_Panel;

    [SerializeField] MenuController menuController;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //PopulateTextureGrid();
    }

    // Update is called once per 
    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Ignore clicks on UI
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            Vector2 screenPos = Mouse.current.position.ReadValue();

            Ray ray = Camera.main.ScreenPointToRay(screenPos);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject obj = hit.collider.gameObject;
                SurfaceData data = obj.GetComponent<SurfaceData>();
                MaterialChanger mat = obj.GetComponent<MaterialChanger>();

                List<Material> materials = null;

                if (data != null)
                {
                    if (data.surfaceType == SurfaceType.Exterior_Wall || data.surfaceType == SurfaceType.Interior_Wall)
                        materials = printedWallMaterials;
                    else if (data.surfaceType == SurfaceType.Floor)
                        materials = floorMaterials;
                }

                if (menuController.menuActive == true) menuController.CloseMenu();

                if (materials != null)
                    PopulateTextureGrid(materials);
  
                menuController.OpenMenu();
                menuController.menuActive = true;

                SelectionManager.Instance.selectedSurface = obj;
            }
        }
    }


    private void PopulateTextureGrid(List<Material> matList)
    {

        foreach (Material mat in matList)
        {
            GameObject newItemSlot = Instantiate(itemSlot, UI_Panel.transform); // Create a new item slot as a child of the UI panel
            RawImage image = newItemSlot.GetComponent<RawImage>();
            ButtonMaterial buttonMat = newItemSlot.GetComponent<ButtonMaterial>();
            if (image != null)
            {
                image.texture = mat.GetTexture("_BaseMap") as Texture2D; // Set the texture of the item slot
            }
            buttonMat.buttonMaterial = mat; 
        }

    }
}
