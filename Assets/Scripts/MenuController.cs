using StarterAssets;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public FirstPersonController fpsController;
    public GameObject UI_Panel;
    public GameObject ExitButton;
    public GameObject ScrollPanel;
    public GameObject ColorIcon;
    public GameObject ColorPreview;

    public GameObject crosshair;
    
    public bool menuActive; // Flag to track if the menu is active


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (ExitButton != null)
        {
            ExitButton.SetActive(false); // Ensure the exit button is initially hidden
        }
        else {
            return;

        }

        if (ScrollPanel != null) { 
        
        
            ScrollPanel.SetActive(false);
        
        }
        if (ColorIcon != null) 
        { 
            ColorIcon.SetActive(false);
        }
        if (ColorPreview != null)
        {
            ColorPreview.SetActive(false);
        }
        else
        {

            return;


        }
    }


    // Update is called once per frame
    void Update()
    {
        if (fpsController != null && menuActive) { 
        
                fpsController.enabled = false; // Disable the FirstPersonController script when the menu is active
                Cursor.visible = true; // Show the cursor
                Cursor.lockState = CursorLockMode.None; // Unlock the cursor
            crosshair.SetActive(false); // Hide the crosshair when the menu is active

        }
        else if (fpsController != null && !menuActive) { 
        
                fpsController.enabled = true; // Enable the FirstPersonController script when the menu is not active
            Cursor.visible = false; // Hide the cursor
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
            crosshair.SetActive(true); // Show the crosshair when the menu is not active

        }

    }


    public void OpenMenu()
    {
        
        if(ScrollPanel != null) 
       {
            ScrollPanel.SetActive(true); // Show the scroll panel
       }

        if (ExitButton != null) 
        {
            ExitButton.SetActive(true); // Show the exit button
        }
        if (ColorIcon != null)
        {
            ColorIcon.SetActive(true);
        }
        if (ColorPreview != null)
        { 
            ColorPreview.SetActive(true); 
        }

    }

    private void DePopulateTextureGrid()
    {
        foreach (Transform itemSlot in UI_Panel.transform)
        {
            Destroy(itemSlot.gameObject);
            //Debug.Log(itemSlot.name);
            //Debug.Log(itemSlot.GetComponent<ButtonMaterial>().buttonMaterial);
        }
    }

    public void CloseMenu()
    {
        menuActive = false; // Set the menuActive flag to false

        if (ExitButton != null)
        {
            ExitButton.SetActive(false); // Hide the exit button
        }
        
        if (ScrollPanel != null) {
            ScrollPanel.SetActive(false);
        }
        if (ColorIcon != null) 
        {
            ColorIcon.SetActive(false);
        }
        if (ColorPreview != null)
        {
            ColorPreview.SetActive(false);
        }

        DePopulateTextureGrid();
    }

}
