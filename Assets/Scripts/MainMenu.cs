using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnStartButton()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void OnQuitButton()
    {
        Application.Quit();
    }
    public void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
