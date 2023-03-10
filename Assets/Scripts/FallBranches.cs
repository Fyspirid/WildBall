using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBranches : MonoBehaviour
{
    [SerializeField] private Rigidbody targetRigidbody;
    [SerializeField] private GameObject destructible;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetRigidbody.isKinematic = false;
        }
    }
}
