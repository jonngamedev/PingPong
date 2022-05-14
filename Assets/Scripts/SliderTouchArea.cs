using UnityEngine;
using UnityEngine.UI;


public class SliderTouchArea : MonoBehaviour
{
    RectTransform rectTransform;

    private void Start()
    {
        // Set touch area of slider to complete screen
        rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

}
