using UnityEngine;
using UnityEngine.InputSystem;

public class MouseClicking : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 screenPos = Mouse.current.position.ReadValue();

            Ray ray = Camera.main.ScreenPointToRay(screenPos);
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("Mouse clicked on: " + hit.collider.gameObject.name);
            }
        }
    }
}
