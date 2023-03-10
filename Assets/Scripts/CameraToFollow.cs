using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToFollow : MonoBehaviour
{
    [SerializeField] private Transform obj;
    private Vector3 posit;
    void Start()
    {
        posit = transform.position - obj.position;
    }
    void Update()
    {
        if (obj)
            transform.position = obj.position + posit;
        else if (!obj)
        {
            Invoke("DestroyCamera", 3);
        }
    }
    private void DestroyCamera()
    {
        posit = transform.position;
    }
}
