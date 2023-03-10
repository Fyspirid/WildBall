using System.Collections;
using UnityEngine;
using TMPro;
public class Tips : MonoBehaviour
{
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private string[] messages;
    private int currentMessage;
    private void Start()
    {
        currentMessage = 0;
        messageText.text = messages[currentMessage];
        StartCoroutine(ChangeMessage());
    }
    IEnumerator ChangeMessage()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);
            currentMessage = Random.Range(0, messages.Length);
            messageText.text = messages[currentMessage];
        }
    }
}
