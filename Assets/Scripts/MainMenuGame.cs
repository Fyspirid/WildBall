using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuGame : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene(5);
    }
    public void SettingButton()
    {

    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
