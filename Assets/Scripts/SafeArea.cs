using UnityEngine;

public class SafeArea : MonoBehaviour
{
    private static Vector2 maxSize;
    public static Vector2 MaxSize
    {
        get
        {
            return maxSize;
        }

        private set { }
    }

    private Camera mainCam;
    private float aspectRatio;
    private float maxScreenWorldWidth;
    private float maxScreenWorldHeight;    


    private void Awake()
    {
        CalculateSafeArea();
    }

   
    private void CalculateSafeArea()
    {
        mainCam = Camera.main;

        // Max screen limits in world cordinates
        aspectRatio = (float)Screen.width / Screen.height;
        maxScreenWorldHeight = mainCam.orthographicSize * 2;
        maxScreenWorldWidth = maxScreenWorldHeight * aspectRatio;

        maxSize.x = maxScreenWorldWidth;
        maxSize.y = maxScreenWorldHeight;
    }
    
}
