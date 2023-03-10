using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBranche : MonoBehaviour
{
    [SerializeField] private GameObject destructible;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == destructible)
        {
            Destroy(destructible);
        }
    }
}
