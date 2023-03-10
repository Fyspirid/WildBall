using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBall : MonoBehaviour
{
    public int force;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(0, 0, force*10, ForceMode.Impulse);
    }
}
