using System;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private int _collisionCount;
    public event Action Finished;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Ball ball) && _collisionCount == 0)
        {
            ball.StopMovement();
            Finished?.Invoke();
            _collisionCount++;
        }
    }
}
