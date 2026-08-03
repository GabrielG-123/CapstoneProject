using StarterAssets;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public FirstPersonController fpsController;
    public GameObject UI_Panel;
    public GameObject ExitButton;
   public GameObject ScrollPanel;
    public GameObject ThreeDSelectionPanel;
    public GameObject floorUI;
    public GameObject crosshair;
    


    public bool menuActive; // Flag to track if the menu is active


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //if (UI_Panel != null)
        //{
        //    UI_Panel.SetActive(false);
        //    // Ensure the UI panel is initially hidden
        //}
        //else {

        //    return;
        
        //}





        if (ExitButton != null)
        {
            ExitButton.SetActive(false); // Ensure the exit button is initially hidden
        }
        else {
            return;

        }

        

        if (ThreeDSelectionPanel != null)
        {
            Debug.Log("ThreeDSelectionPanel is assigned in the inspector.");
            ThreeDSelectionPanel.SetActive(false); // Ensure the 3D selection panel is initially hidden
        }
        else
        {
            Debug.LogWarning("ThreeDSelectionPanel is not assigned in the inspector.");
            return;
        }

        if (ScrollPanel != null) { 
        
        
            ScrollPanel.SetActive(false);
        
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
       //
       //UI_Panel.SetActive(true); // Show the UI panel
       
        
        if(ScrollPanel != null) 
       {
            if (SelectionManager.Instance.floorClicked)
            {
                ScrollPanel.SetActive(true); // Show the scroll panel
            }
       }

        if (ExitButton != null) 
        {
            ExitButton.SetActive(true); // Show the exit button
        }


    }


    public void CloseMenu()
    {
        //  UI_Panel.SetActive(false); // Hide the UI panel
        menuActive = false; // Set the menuActive flag to false
        SelectionManager.Instance.wallClicked = false;
        SelectionManager.Instance.floorClicked = false;
        if (ExitButton != null)
        {
            ExitButton.SetActive(false); // Hide the exit button
        }
       

        if (ThreeDSelectionPanel != null)
        {
            ThreeDSelectionPanel.SetActive(false); // Hide the 3D selection panel
        }

        
        
        if (ScrollPanel != null) {
            ScrollPanel.SetActive(false);
        
        }
    }

}
