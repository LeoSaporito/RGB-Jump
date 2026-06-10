using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformCollider : MonoBehaviour
{
    PlayerColor playerColor;

    TilemapCollider2D _tc;

    void Start()
    {
        playerColor = FindFirstObjectByType<PlayerColor>();

        _tc = GetComponent<TilemapCollider2D>();
    }
    void Update()
    {
        ActivateRedPlatforms();
        ActivateGreenPlatforms();
        ActivateBluePlatforms();
    }
    void ActivateRedPlatforms()
    {
        if (playerColor.GetRedBool())
        {
            if (LayerMask.LayerToName(gameObject.layer) == "Red")
            {
                _tc.enabled = true;
            }
            if (LayerMask.LayerToName(gameObject.layer) == "Green")
            {
                _tc.enabled = false;
            }
            if (LayerMask.LayerToName(gameObject.layer) == "Blue")
            {
                _tc.enabled = false;
            }
        }
    }
    void ActivateGreenPlatforms()
    {
        if (playerColor.GetGreenBool())
        {
            if (LayerMask.LayerToName(gameObject.layer) == "Red")
            {
                _tc.enabled = false;
            }
            if (LayerMask.LayerToName(gameObject.layer) == "Green")
            {
                _tc.enabled = true;
            }
            if (LayerMask.LayerToName(gameObject.layer) == "Blue")
            {
                _tc.enabled = false;
            }
        }
    }
    void ActivateBluePlatforms()
    {
        if (playerColor.GetBlueBool())
        {
            if (LayerMask.LayerToName(gameObject.layer) == "Red")
            {
                _tc.enabled = false;
            }
            if (LayerMask.LayerToName(gameObject.layer) == "Green")
            {
                _tc.enabled = false;
            }
            if (LayerMask.LayerToName(gameObject.layer) == "Blue")
            {
                _tc.enabled = true;
            }
        }
    }
}
