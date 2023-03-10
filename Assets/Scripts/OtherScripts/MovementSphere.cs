using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementSphere : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            float translation = speed;
            translation *= Time.deltaTime;
            transform.Translate(translation, 0, 0);
            anim.SetBool("runs", true);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            anim.SetBool("runs", false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            float translation = -speed;
            translation *= Time.deltaTime;
            transform.Translate(0, 0, translation);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            float translation = speed;
            translation *= Time.deltaTime;
            transform.Translate(0, 0, translation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Respawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Connect");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
