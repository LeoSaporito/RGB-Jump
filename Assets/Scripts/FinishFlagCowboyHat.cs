using TMPro;
using UnityEngine;
using System.Collections;

public class FinishFlagCowboyHat : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject hatFound;
    [SerializeField] GameObject notYourHat;
    [SerializeField] TextMeshProUGUI hatFoundText;
    [SerializeField] TextMeshProUGUI notYourHatText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CowboyHatClip());
        }
    }
    IEnumerator CowboyHatClip()
    {
        player.GetComponent<SpriteRenderer>().enabled = false;
        hatFound.SetActive(true);
        hatFoundText.enabled = true;
        yield return new WaitForSeconds(2f);
        hatFound.SetActive(false);
        notYourHat.SetActive(true);
        notYourHatText.enabled = true;
    }
}
