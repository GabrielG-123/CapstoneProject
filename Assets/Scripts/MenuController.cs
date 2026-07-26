using StarterAssets;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public FirstPersonController fpsController;
    public GameObject UI_Panel;
    public GameObject ExitButton;



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
    }

    // Update is called once per frame
    void Update()
    {
        if (fpsController != null && menuActive) { 
        
                fpsController.enabled = false; // Disable the FirstPersonController script when the menu is active

        }
        else if (fpsController != null && !menuActive) { 
        
                fpsController.enabled = true; // Enable the FirstPersonController script when the menu is not active
        }

    }


    public void OpenMenu()
    {
        UI_Panel.SetActive(true); // Show the UI panel
        if (ExitButton != null) 
        {
            ExitButton.SetActive(true); // Show the exit button
        }


    }


    public void CloseMenu()
    {
        UI_Panel.SetActive(false); // Hide the UI panel
        menuActive = false; // Set the menuActive flag to false
        if (ExitButton != null)
        {
            ExitButton.SetActive(false); // Hide the exit button
        }
    }


}
