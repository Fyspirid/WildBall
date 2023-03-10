using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public float speed;
    public Vector3 location;
    private void Start()
    {
        GetComponent<Collider>();
    }
    private void Update()
    {
        Movement();
    }
    void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, location, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            other.attachedRigidbody.useGravity = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody)
        {
            other.attachedRigidbody.useGravity = true;
        }
    }
}
