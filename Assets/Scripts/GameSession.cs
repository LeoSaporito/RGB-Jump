using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;
using UnityEngine.SceneManagement;
public class GameSession : MonoBehaviour
{
    [SerializeField] int numOfLives = 3;
    [SerializeField] TextMeshProUGUI livesText;

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
        livesText.text = "Lives: " + numOfLives;        
    }

    public void PlayerDeath()
    {
        if (numOfLives > 1)
        { 
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }
    void TakeLife()
    {        
        numOfLives--;        

        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
        livesText.text = "Lives: " + numOfLives;        
    }
    private void ResetGameSession()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenu");
    }
}
