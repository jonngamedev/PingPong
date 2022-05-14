using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] Vector2 forceToBall = new Vector2(0,1);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.rigidbody.AddForce(forceToBall);
    }
    
}
