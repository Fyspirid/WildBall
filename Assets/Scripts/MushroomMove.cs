using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MushroomMove : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speedMush;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(speedMush, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-speedMush, 0f, 0f);
        }
    }
}
