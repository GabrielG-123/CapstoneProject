using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour
{
    public Texture textureImage;

    public void WallTextureApply(GameObject clickedButton) {
        
        // Now you get the RawImage from the button that was clicked
        RawImage rawImage = clickedButton.GetComponent<RawImage>();

        if (rawImage != null)
        {
            Debug.Log("The name of the button is: " + clickedButton.name);
            Debug.Log("Button texture: " + rawImage.texture.name);

            textureImage = rawImage.texture; // Assign the texture from the clicked button to the textureImage variable
        }

        if (SelectionManager.Instance.selectedWall != null)
        {
            Renderer wallRenderer = SelectionManager.Instance.selectedWall.GetComponent<Renderer>();
            if (wallRenderer != null)
            {
                Debug.Log("Applying texture to wall: " + SelectionManager.Instance.selectedWall.name);
                wallRenderer.material.mainTexture = textureImage;
            }
        }
    }
}
