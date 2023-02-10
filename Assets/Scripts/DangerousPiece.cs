using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousPiece : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Ball ball))
        {
            ball.Fail();
            ball.StopMovement();
        }
    }
}
