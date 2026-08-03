using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour
{
    public Texture textureImage;
    public MaterialChanger wall;
    public Renderer wallRenderer;
    public Material smoothFinish;
    public Material threeDPrintedFinish;

    private void Update()
    {
        if (SelectionManager.Instance != null && SelectionManager.Instance.selectedWall != null)
        {
            wall = SelectionManager.Instance.selectedWall.GetComponent<MaterialChanger>();
            wallRenderer = SelectionManager.Instance.selectedWall.GetComponent<Renderer>(); 
            smoothFinish = SelectionManager.Instance.selectedWall.GetComponent<Wall_Click>().smoothFinish;
            threeDPrintedFinish = SelectionManager.Instance.selectedWall.GetComponent<Wall_Click>().threeDPrintedFinish;

        }
        else
        {
            wall = null;
        }
    }


    public void FloorTextureApply(GameObject clickedButton)
    {

        // Now you get the RawImage from the button that was clicked
        RawImage rawImage = clickedButton.GetComponent<RawImage>();

        if (rawImage != null)
        {
            Debug.Log("The name of the button is: " + clickedButton.name);
            Debug.Log("Button texture: " + rawImage.texture.name);

            textureImage = rawImage.texture; // Assign the texture from the clicked button to the textureImage variable
        }

        if (SelectionManager.Instance.selectedFloor != null)
        {
            Renderer wallRenderer = SelectionManager.Instance.selectedFloor.GetComponent<Renderer>();
            if (wallRenderer != null)
            {
               // Debug.Log("Applying texture to wall: " + SelectionManager.Instance.selectedWall.name);
                wallRenderer.material.mainTexture = textureImage;
            }
        }
    }



    public void SmoothFinishClick()
    {

        if (wall == null) wallRenderer.material = smoothFinish;
        else wall.ChangeMaterial(smoothFinish);

        Debug.Log("Smooth finish applied to wall: " + gameObject.name);



    }


    public void ExposedFinishClick()
    {


        if (wall == null) wallRenderer.material = threeDPrintedFinish;
        else wall.ChangeMaterial(threeDPrintedFinish);


    }

}
