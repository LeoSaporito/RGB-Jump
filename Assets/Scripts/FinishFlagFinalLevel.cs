using UnityEngine;

public class FinishFlagFinalLevel : MonoBehaviour
{
    GameObject TextPanelOne;
    bool isDialogStarted;
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindFirstObjectByType<DialogueManager>().DialogueBeforeChase();
        }
    }

    public bool GetIsDialogueStartedBool() { return isDialogStarted; }

}