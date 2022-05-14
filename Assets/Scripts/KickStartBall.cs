using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickStartBall : MonoBehaviour
{
    [Header("Add Reference")]
    [SerializeField] Rigidbody2D ballRigidBody;

    [Header("Start Parameters")]
    [SerializeField] Vector2 forcetoBall;

    private void Start()
    {
        AddForceToBall();
    }

    private void AddForceToBall()
    {
        if (ballRigidBody != null)
        {
            ballRigidBody.AddForce(forcetoBall);
        }
    }
}
