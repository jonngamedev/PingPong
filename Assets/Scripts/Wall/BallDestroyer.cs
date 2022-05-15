using System;
using UnityEngine;


public class BallDestroyer : MonoBehaviour
{
    // Actions
    public static Action<GameObject> OnBallDisable;

    // Should be true for bottom wall
    [Header("Wall Parameters")]    
    [SerializeField] private bool isBallDestroyer = false;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (isBallDestroyer && collision.gameObject.tag != Utilities.powerUpTag)
        {
            // Disable Ball
            collision.gameObject.SetActive(false);


            // Raise Ball diabled event
            if (OnBallDisable != null)
            {
                OnBallDisable(collision.gameObject);
            }
        }        
    }
}
