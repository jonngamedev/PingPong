using System;
using UnityEngine;

public class WallSettings : MonoBehaviour
{
    [SerializeField]
    private Utilities.WallType wallType;

    private Vector3 scale;
    private Vector3 position = Vector3.zero;


    private void Start()
    {
        Initializations();
        SetWallPositionAndSize();
    }   

    // Auto set wall positions and scale as per screen size
    private void SetWallPositionAndSize()
    {
        switch (wallType)
        {
            case Utilities.WallType.Top:
                scale.x = SafeArea.MaxSize.x;
                position.y += ((SafeArea.MaxSize.y / 2) + scale.y);

                transform.localScale = scale;
                transform.position = position;
                break;

            case Utilities.WallType.Bottom:
                scale.x = SafeArea.MaxSize.x;
                position.y -= ((SafeArea.MaxSize.y / 2) + scale.y);

                transform.localScale = scale;
                transform.position = position;
                break;

            case Utilities.WallType.Left:
                scale.y = SafeArea.MaxSize.y;
                position.x -= ((SafeArea.MaxSize.x / 2) + scale.x);

                transform.localScale = scale;
                transform.position = position;
                break;

            case Utilities.WallType.Right:
                scale.y = SafeArea.MaxSize.y;
                position.x += ((SafeArea.MaxSize.x / 2) + scale.x);

                transform.localScale = scale;
                transform.position = position;
                break;

            default:
                break;
        }
    }

    private void Initializations()
    {
        scale = transform.localScale;
        transform.localPosition = position;      
    }
}
