using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class BarPositionControl : MonoBehaviour
{
    [Header("Add References")]
    [SerializeField] Slider sliderPositionControl;

    private Sprite barSprite;
    private Vector3 barStartPosition;
    private Vector3 barCurrentPosition;
    private float barWidth;

    private void Start()
    {
        SubscribeEvents();
        Initializations();        
    }

    // Update bar position in as per slider value
    // Whenever there is a change in slider position
    private void UpdateBarPosition(float sliderValue)
    {
        barCurrentPosition.x = sliderValue;
        transform.position = barCurrentPosition;
    }


    // Set slider movement as per screen size
    private void SetSliderMovementLimits()
    {       
        // Evaluate Bar width
        barSprite = GetComponent<SpriteRenderer>().sprite;

        // Bar width is same as bounds because while importing pixel per unit is equal to it's size
        barWidth = barSprite.bounds.size.x;

        float halfWidth = (SafeArea.MaxSize.x - barWidth) / 2f;
        sliderPositionControl.minValue = -halfWidth;
        sliderPositionControl.maxValue = halfWidth;
        sliderPositionControl.value = 0;
    }


    // Resetting bar position
    public void PlaceBarAtCentre(GameObject gameObject = null)
    {   
        // Place bar at centre
        barStartPosition = transform.position;
        barStartPosition.x = 0;
        transform.position = barStartPosition;
        barCurrentPosition = barStartPosition;

        // Reset slider
        sliderPositionControl.value = 0;
    }

    private void SubscribeEvents()
    {
        sliderPositionControl.onValueChanged.AddListener(delegate { UpdateBarPosition(sliderPositionControl.value);});
        BallDestroyer.OnBallDisable += PlaceBarAtCentre;
    }

    private void Initializations()
    {        
        PlaceBarAtCentre();
        SetSliderMovementLimits();
    }
}
