using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LeafMove : MonoBehaviour
{
    [SerializeField] private float speedLeaf = 0.5f;
    [SerializeField] private Transform targetLeaf;
    [SerializeField] private ParticleSystem effectActivatedLeaf;
    private bool isMovingLeaf = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isMovingLeaf)
        {
            isMovingLeaf= true;
            effectActivatedLeaf.Stop();
        }
    }
    private void Update()
    {
        if (isMovingLeaf)
        {
            transform.position = Vector3.Lerp(transform.position, targetLeaf.position, speedLeaf * Time.deltaTime);
            if (transform.position == targetLeaf.position)
            {
                isMovingLeaf = false;
            }
        }
    }
}
