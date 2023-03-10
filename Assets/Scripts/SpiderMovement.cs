using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    [SerializeField] private Vector3[] target;
    [SerializeField] private float speed;
    private Animator animSpyder;
    private int i;
    private void Start()
    {
        i = Random.Range(0, target.Length);
        animSpyder = GetComponent<Animator>();
    }
    private void Update()
    {
        MoveLogicSpider();
    }
    private void MoveLogicSpider()
    {
        transform.LookAt(target[i]);
        animSpyder.SetBool("go", true);
        transform.position = Vector3.MoveTowards(transform.position, target[i], speed * Time.deltaTime);

        if (target[i] == transform.position)
        {
            animSpyder.SetBool("go", false);
            i = Random.Range(0, target.Length);
            transform.LookAt(target[i]);
            transform.position = Vector3.MoveTowards(transform.position, target[i], speed * Time.deltaTime);
            animSpyder.SetBool("go", true);
        }
    }
}
