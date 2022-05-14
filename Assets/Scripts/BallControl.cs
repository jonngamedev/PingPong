using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallControl : MonoBehaviour
{
    [Header("Ball Parameters")]
    [SerializeField] Vector3 ballCentrePosition = new Vector3(0, -3.7f, 0);
    

    public void PlaceBallAtCentre()
    {
        transform.position = ballCentrePosition;
    }

}
