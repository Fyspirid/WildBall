using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectedBalls : MonoBehaviour
{
    public TMP_Text score;
    private int a;
    private int b;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Others"))
        {
            a++;
            score.text = "\n" + a;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            b++;
            score.text = "\n\n\n" + b;
        }
    }
}
