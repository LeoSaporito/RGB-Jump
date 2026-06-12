using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;
using UnityEngine.SceneManagement;
public class GameSession : MonoBehaviour
{
    [SerializeField] int currentSceneIndex;
    [SerializeField] TextMeshProUGUI levelsText;

    private void Awake()
    {
        int numOfGameSessions = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;

        if (numOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelsText.text = "Level: " + currentSceneIndex;
    }

    public void PlayerDeath()
    {
        ReloadScene();
    }
    void ReloadScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }    
    public void LoadNextLevel()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        currentSceneIndex++;
        SceneManager.LoadScene(currentSceneIndex);
        levelsText.text = "Level: " + currentSceneIndex;
    }
}
