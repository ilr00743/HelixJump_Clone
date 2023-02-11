using System;
using UnityEngine;

public class CircleDisableTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball))
        {
            Debug.Log("Trigger");
            transform.parent.gameObject.SetActive(false);
        }
    }
}