using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFlag : MonoBehaviour
{
    [SerializeField] bool hatLevel;
    [SerializeField] float delay;
    [SerializeField] Animator playerAnimator;
    [SerializeField] GameObject playerCowboyHat;
    [SerializeField] GameObject levelCowboyHat;
    [SerializeField] GameObject hatFoundText;
    [SerializeField] GameObject wrongHatText;

    Coroutine cowboyHatFoundCoroutine;

    bool isHatAnimation;
    private void Start()
    {
        isHatAnimation = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (cowboyHatFoundCoroutine == null && hatLevel)
            {
                PlayerWearingCowboyHat();
                cowboyHatFoundCoroutine = StartCoroutine(CowboyHatFound());
            }
            else
            {
                FindAnyObjectByType<GameSession>().LoadNextLevel();
            }          
        }
    }
    void PlayerWearingCowboyHat()
    {
        isHatAnimation = true;
        playerCowboyHat.SetActive(true);
        levelCowboyHat.SetActive(false);
    }
    IEnumerator CowboyHatFound()
    {
        hatFoundText.SetActive(true);
        playerAnimator.SetBool("foundCowboyHat", true);
        yield return new WaitForSeconds(delay);

        wrongHatText.SetActive(true);
        playerAnimator.SetBool("wrongHat", true);
        yield return new WaitForSeconds(delay);

        FindAnyObjectByType<GameSession>().LoadNextLevel();
    }
    public bool GetIsHatAnimationBool() { return isHatAnimation; }
}
