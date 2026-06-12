using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;
using UnityEngine.SceneManagement;
public class GameSession : MonoBehaviour
{
    //[SerializeField] int numOfLives = 3;
    //[SerializeField] TextMeshProUGUI livesText;
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
        //livesText.text = "Lives: " + numOfLives;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelsText.text = "Level: " + currentSceneIndex;
    }

    public void PlayerDeath()
    {
        ReloadScene();

        //if (numOfLives > 1)
        //{ 
        //    TakeLife();
        //}
        //else
        //{
        //    SceneManager.LoadScene("GameOver");
        //    ResetGameSession();
        //}
    }
    void ReloadScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }
    void TakeLife()
    {        
        //numOfLives--;        

        //string currentScene = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(currentScene);
        //livesText.text = "Lives: " + numOfLives;        
    }
    private void ResetGameSession()
    {
        //Destroy(gameObject);
    }

    public void LoadNextLevel()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        currentSceneIndex++;
        SceneManager.LoadScene(currentSceneIndex);
        levelsText.text = "Level: " + currentSceneIndex;
    }
}
