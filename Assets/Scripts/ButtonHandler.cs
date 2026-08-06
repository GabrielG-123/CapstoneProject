using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ButtonHandler : MonoBehaviour
{
    public ColorWheelPicker colorPicker;

    void Start() {
        SelectionManager.Instance.surfaces = FindObjectsByType<SurfaceData>();
        foreach (SurfaceData surface in SelectionManager.Instance.surfaces)
        {
            if (surface.surfaceType == SurfaceType.Exterior_Wall ||
                surface.surfaceType == SurfaceType.Interior_Wall)
            {
                SelectionManager.Instance.printedWalls.Add(surface);
            }
        }

        CalculateTakeOff();
    }

    private void Update()
    {
        /*
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
        */
    }

    public void CalculateTakeOff() {
        Material smoothFinish = SelectionManager.Instance.smoothFinish;
        SelectionManager.Instance.takeOff = 0;

        foreach (SurfaceData wall in SelectionManager.Instance.printedWalls) {
            if (wall.GetComponent<Renderer>().material.name.Contains(smoothFinish.name))
            {
                SelectionManager.Instance.takeOff += wall.Area;
            }
        }

        SelectionManager.Instance.takeoffText.text = $"Smooth Finish: {SelectionManager.Instance.takeOff:F1} sq ft";
    }

    public void ApplyColor()
    {
        if (SelectionManager.Instance.selectedSurface == null)
        {
            Debug.LogWarning("No surface selected!");
            return;
        }

        Renderer renderer = SelectionManager.Instance.selectedSurface.GetComponent<Renderer>();

        Color pickedColor = colorPicker.SelectedColor;

        renderer.material.SetColor("_BaseColor", pickedColor);
    }

    public void ApplyMaterial(GameObject clickedButton)
    {
        Renderer renderer = SelectionManager.Instance.selectedSurface.GetComponent<Renderer>();

        Material surfaceMat = renderer.material;
        Color surfaceColor = renderer.material.color;
        Material smoothFinish = SelectionManager.Instance.smoothFinish;

        MaterialChanger surface = SelectionManager.Instance.selectedSurface.GetComponent<MaterialChanger>();
        Material mat = clickedButton.GetComponent<ButtonMaterial>().buttonMaterial;
        surface.ChangeMaterial(mat);

        renderer.material.SetColor("_BaseColor", surfaceColor);
 
        if (surfaceMat.name.Contains(smoothFinish.name) || mat == smoothFinish)
        {
            CalculateTakeOff();
            //Debug.Log($"Takeoff is: {SelectionManager.Instance.takeOff}");
        }
            
    }
}
