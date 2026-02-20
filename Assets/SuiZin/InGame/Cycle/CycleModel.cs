using System;
using UnityEngine;
using R3;

public class CycleModel:MonoBehaviour
{
    public readonly ReactiveProperty<bool> _isPlayerInRange = new(false);
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRange.Value = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRange.Value = false;
        }
    }
}

