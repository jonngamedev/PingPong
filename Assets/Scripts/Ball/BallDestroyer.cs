using System;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    public static Action<GameObject> OnBallDisable;

    [SerializeField] private bool isBallDestroyer = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBallDestroyer)
        {
            collision.gameObject.SetActive(false);

            if (OnBallDisable != null)
            {
                OnBallDisable(collision.gameObject);
            }
        }        
    }
}
