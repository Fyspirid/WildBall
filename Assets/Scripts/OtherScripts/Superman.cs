using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superman : MonoBehaviour
{
    public float Power;
    public float Radius;
    public float Speed;
    public Vector3 Finish;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Finish, Speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
         Rigidbody[] blocks = FindObjectsOfType<Rigidbody>();
         foreach (Rigidbody B in blocks)
         {
             if (Vector3.Distance(transform.position, B.transform.position) < Radius)
             {
                Vector3 direction = B.transform.position - transform.position;
                B.AddForce(direction.normalized * Power * (Radius - Vector3.Distance(transform.position, B.transform.position)), ForceMode.Impulse);
             }
         }
    }
}
