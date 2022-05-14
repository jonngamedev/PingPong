using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class BarPositionControl : MonoBehaviour
{
    [Header("Required References")]
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

    private void UpdateBarPosition(float xValue)
    {
        barCurrentPosition.x = xValue;
        transform.position = barCurrentPosition;
    }

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

    public void PlaceBarAtCentre()
    {   
        // Place bar at centre
        barStartPosition = transform.position;
        barStartPosition.x = 0;
        transform.position = barStartPosition;
        barCurrentPosition = barStartPosition;
    }

    private void SubscribeEvents()
    {
        sliderPositionControl.onValueChanged.AddListener(delegate { UpdateBarPosition(sliderPositionControl.value);});
    }

    private void Initializations()
    {        
        PlaceBarAtCentre();
        SetSliderMovementLimits();
    }
}
