using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle : MonoBehaviour
{
    [SerializeField] private Vector3[] target;
    [SerializeField] private float speed;
    [SerializeField] private float detectionDistance;
    [SerializeField] private float dropDelay;
    [SerializeField] private Transform player;
    private bool isPlayerDetected = false;
    private bool isDropping = false;
    private int i;
    private void Start()
    {
        i = Random.Range(0, target.Length);
    }
    void Update()
    {
        FlyingBeetle();
        DetectedPlayer();
    }
    private void FlyingBeetle()
    {
        transform.LookAt(target[i]);
        transform.position = Vector3.MoveTowards(transform.position, target[i], speed * Time.deltaTime);

        if (target[i] == transform.position)
        {
            i = Random.Range(0, target.Length);
            transform.LookAt(target[i]);
            transform.position = Vector3.MoveTowards(transform.position, target[i], speed * Time.deltaTime);
        }
    }
    private void DetectedPlayer()
    {
        if (player == null) return;
            float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= detectionDistance)
        {
            isPlayerDetected = true;
        }
        else
        {
            isPlayerDetected = false;
        }
        if (isPlayerDetected && !isDropping)
        {
            StartCoroutine(DropAfterDelay());
        }
        if (isDropping)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
    IEnumerator DropAfterDelay()
    {
        isDropping = false;
        transform.LookAt(player.position);
        yield return new WaitForSeconds(dropDelay);
        isDropping = true;
    }
}
