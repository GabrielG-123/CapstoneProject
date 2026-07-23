using StarterAssets;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public FirstPersonController fpsController; // Reference to the FirstPersonController script

    public bool menuActive; // Flag to track if the menu is active


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
}
