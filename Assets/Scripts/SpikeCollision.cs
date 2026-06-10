using UnityEngine;
using UnityEngine.Tilemaps;

public class SpikeCollision : MonoBehaviour
{
    PlayerMovement playerMovement;
    TilemapCollider2D _tc;
    void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
        _tc = GetComponent<TilemapCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement.Die();
            _tc.enabled = false;
        }
    }
}
