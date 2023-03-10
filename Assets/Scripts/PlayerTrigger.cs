using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using static UnityEngine.ParticleSystem;
using Unity.VisualScripting;
using WildBall.Inputs;

public class PlayerTrigger : MonoBehaviour
{
    public GameObject loseMenu;
    private GameObject loseCurrent;
    public Animator anim;
    public TMP_Text menuGameMessage;
    public GameObject collisionDoor;
    public GameObject bridge;
    public GameObject activatedStone;
    [SerializeField] private GameObject[] prefabInsect;
    [SerializeField] private ParticleSystem bonusEffect;
    [SerializeField] private ParticleSystem die;
    [SerializeField] private ParticleSystem buttonEffect;
    [SerializeField] private GameObject parentsObj;
    //Win Game
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera victoryCamera;
    [SerializeField] private GameObject canvasWin;
    private PlayerMovement scriptMove;

    [SerializeField] private TMP_Text bonusNumber;
    private int bonusCount;
    private void Awake()
    {
        scriptMove = GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (other.CompareTag("Enemy"))
        {
            Die();
            Invoke("Lose", 1);
        }
        if (other.CompareTag("Smell")) // отпугивание запахом
        {
            buttonEffect.Stop();
            ScareAway();
        }
        if (other.CompareTag("Trap"))
        {
            activatedStone.SetActive(false);
        }
        if (other.gameObject.CompareTag("Bonus"))
        {
            bonusCount++;
            bonusNumber.text = "Bonus: " + bonusCount.ToString();
            Bonus();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("EndGame"))
        {
            SwitchVictory();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            Door();
        }
        if (other.CompareTag("Toogle"))
        {
            ToggleMethod();
        }
        if (other.CompareTag("MessageActivator")) // вывод сообщения о том что необходимо активировать мост
        {
            menuGameMessage.gameObject.SetActive(true);
            Destroy(parentsObj);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MessageActivator")) // деактивация сообщения о том что необходимо активировать мост
        {
            menuGameMessage.gameObject.SetActive(false);
        }
        if (other.CompareTag("Toogle"))
        {
            menuGameMessage.gameObject.SetActive(false);
        }
    }
    private void ToggleMethod() // активация тумблера
    {
        menuGameMessage.gameObject.SetActive(true);
        if (Input.GetKeyUp(KeyCode.E))
        {
            anim.SetBool("ToogleAtcivated", true);
            if (bridge.activeSelf)
            {
                bridge.SetActive(false);
            }
            else
            {
                bridge.SetActive(true);
            }
        }
    }
    private void Lose() // логика проигрыша
    {
        loseCurrent = Instantiate(loseMenu);
        loseCurrent.SetActive(true);
        Time.timeScale = 0;
    }
    private void Door() // открывание двери
    {
        menuGameMessage.gameObject.SetActive(true);
        if (Input.GetKey(KeyCode.E))
        {
            anim.SetBool("OpenDoor", true);
            menuGameMessage.gameObject.SetActive(false);
            menuGameMessage.text = "Press E to open the door";
        }
    }
    private void Die()
    {
        die.transform.position = transform.position;
        die.Play();
        GameObject childObj = transform.Find("MainSphere").gameObject;
        Destroy(childObj);
    }
    private void Bonus()
    {
        bonusEffect.transform.position = transform.position;
        bonusEffect.Play();
    }
    private void ScareAway()
    {
        for (int i = 0; i < prefabInsect.Length; i++)
        {
            Destroy(prefabInsect[i]);
        }
    }
    private void SwitchVictory()
    {
        mainCamera.enabled = false;
        victoryCamera.enabled = true;
        canvasWin.SetActive(true);
        scriptMove.StopPlayer();
    }
}
