using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button[] clickSelectLevel = new Button[5];
    private void Start()
    {
        for (int i = 0; i < clickSelectLevel.Length; i++)
        {
            int sceneNumber = i;
            clickSelectLevel[i].onClick.AddListener(() => LoadScene(sceneNumber));
        }
    }
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
        Time.timeScale = 1;
    }
}
