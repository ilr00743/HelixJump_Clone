using System;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private int _collisionCount;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Ball ball) && _collisionCount == 0)
        {
            ball.StopMovement();
            ball.Finish();
            _collisionCount++;
        }
    }
}
