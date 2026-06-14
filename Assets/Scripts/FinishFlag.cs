using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFlag : MonoBehaviour
{
    [SerializeField] bool hatLevel;
    [SerializeField] float delay;
    [SerializeField] Animator playerAnimator;
    [SerializeField] GameObject playerHat;
    [SerializeField] GameObject levelHat;
    [SerializeField] GameObject hatFoundText;
    [SerializeField] GameObject wrongHatText;

    [SerializeField] GameObject lockedUI;
    [SerializeField] GameObject unlockedUI;

    Coroutine hatFoundCoroutine;

    public bool isHatAnimation;
    private void Start()
    {
        isHatAnimation = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (hatFoundCoroutine == null && hatLevel)
            {
                PlayerWearingHat();
                hatFoundCoroutine = StartCoroutine(HatFound());
            }
            else if(!hatLevel)
            {
                FindAnyObjectByType<LevelManager>().LoadNextLevel();
            }          
        }
    }
    void PlayerWearingHat()
    {
        isHatAnimation = true;
        unlockedUI.SetActive(true);
        lockedUI.SetActive(false);
        playerHat.SetActive(true);
        levelHat.SetActive(false);
    }
    IEnumerator HatFound()
    {
        hatFoundText.SetActive(true);
        playerAnimator.SetBool("foundHat", true);
        yield return new WaitForSeconds(delay);

        wrongHatText.SetActive(true);
        playerAnimator.SetBool("wrongHat", true);
        yield return new WaitForSeconds(delay);

        FindAnyObjectByType<LevelManager>().LoadNextLevel();
    }
    public bool GetIsHatAnimationBool() { return isHatAnimation; }
}
