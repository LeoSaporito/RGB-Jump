using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int currentSceneIndex;
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void PlayerDeath()
    { 
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadNextLevel()
    { 
        currentSceneIndex++;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
