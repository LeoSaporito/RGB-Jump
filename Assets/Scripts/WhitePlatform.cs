using UnityEngine;

public class WhitePlatform : MonoBehaviour
{
    PlayerColor playerColor;

    private void Start()
    {
        playerColor = FindFirstObjectByType<PlayerColor>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerColor.GetSpriteRenderer().color = Color.white;
        }        
    }
}
