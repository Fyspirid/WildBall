using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float TimeToExplosion;
    public float Power;
    public float Radius;
    void Update()
    {
        TimeToExplosion -= Time.deltaTime;

        if(TimeToExplosion <= 0)
        {
            Boom();
        }
    }
    void Boom()
    {
        Rigidbody[] obj = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody A in obj) 
        {
            if (Vector3.Distance(transform.position, A.transform.position) < Radius)
            {
                Vector3 direction = A.transform.position - transform.position;
                A.AddForce(direction.normalized * Power * (Radius - Vector3.Distance(transform.position, A.transform.position)), ForceMode.Impulse);
            }
        }
        TimeToExplosion = 5;
    }
}
