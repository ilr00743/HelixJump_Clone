using System;
using UnityEngine;

public class CircleDisableTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}