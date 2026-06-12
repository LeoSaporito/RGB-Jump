using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFlag : MonoBehaviour
{
    [SerializeField] GameObject hatFoundSO;
    HatFoundSO hatFound;

    Coroutine hatFoundCoroutine;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (hatFoundSO != null && hatFoundCoroutine == null)
            {
                hatFoundCoroutine = StartCoroutine(HatFound());
            }
            else
            { 
                FindAnyObjectByType<GameSession>().LoadNextLevel();            
            }
        }
    }

    IEnumerator HatFound()
    {
        hatFound.GetPlayer().GetComponent<SpriteRenderer>().enabled = false;
        hatFound.GetHatFound().SetActive(true);
        yield return new WaitForSeconds(2f);
        
        hatFound.GetHatFound().SetActive(false);
        hatFound.GetNotYourHat().SetActive(true);
        yield return new WaitForSeconds(2f);
    
        FindAnyObjectByType<GameSession>().LoadNextLevel();
    }
}
