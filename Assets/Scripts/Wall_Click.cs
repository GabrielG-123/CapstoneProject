using UnityEngine;

public class Wall_Click : MonoBehaviour
{
    public GameObject UI_Panel; // Reference to the UI panel you want to show




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (UI_Panel != null)
        {
            UI_Panel.SetActive(false); // Ensure the UI panel is initially hidden
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDown()
    {
        if (UI_Panel != null)
        {
            UI_Panel.SetActive(true); // Show the UI panel when the wall is clicked
        }
    }
}
