using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ColorWheelPicker : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public Image colorWheel;
    public Image preview;
    public TMP_Text hexText;

    public Color SelectedColor { get; private set; }

    private Texture2D colorTexture;

    private void Awake()
    {
        colorTexture = colorWheel.sprite.texture;
        SelectedColor = Color.white;

        string hex = ColorUtility.ToHtmlStringRGB(SelectedColor);
            hexText.text = "Click to Apply Color: #" + hex;

            float brightness =
                SelectedColor.r * 0.299f +
                SelectedColor.g * 0.587f +
                SelectedColor.b * 0.114f;

            hexText.color = brightness > 0.5f ? Color.black : Color.white;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PickColor(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        PickColor(eventData);
    }

    private void PickColor(PointerEventData eventData)
    {
        RectTransform rect = colorWheel.rectTransform;

        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rect,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localPoint))
            return;


        Rect r = rect.rect;

        float x = Mathf.InverseLerp(r.xMin, r.xMax, localPoint.x);
        float y = Mathf.InverseLerp(r.yMin, r.yMax, localPoint.y);

        SelectedColor = colorTexture.GetPixelBilinear(x, y);

        if (preview != null)
        {
            preview.color = SelectedColor;
            string hex = ColorUtility.ToHtmlStringRGB(SelectedColor);
            hexText.text = "Click to Apply Color: #" + hex;

            float brightness =
                SelectedColor.r * 0.299f +
                SelectedColor.g * 0.587f +
                SelectedColor.b * 0.114f;

            hexText.color = brightness > 0.5f ? Color.black : Color.white;
        }
    }
}