using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallControl : MonoBehaviour
{
    [Header("Ball Parameters")]
    [SerializeField] Vector3 ballCentrePosition = new Vector3(0, -3.7f, 0);
    [SerializeField] Vector2 forcetoBall = new Vector2(10, 30);

    private Rigidbody2D ballRigidBody;


    private void Awake()
    {
        Initializations();        
    }

    private void OnEnable()
    {

        PlaceBallAtCentre();
        AddForceToBall();
    }


    public void PlaceBallAtCentre()
    {
        transform.position = ballCentrePosition;
    }

    public void AddForceToBall()
    {
        if (ballRigidBody != null)
        {
            ballRigidBody.AddForce(forcetoBall);
        }
    }


    private void Initializations()
    {
        ballRigidBody = GetComponent<Rigidbody2D>();
    }
}
