using UnityEngine;

public class PlatformSwitcher : MonoBehaviour
{
    [Header("Red")]
    [SerializeField] GameObject redActive;
    [SerializeField] GameObject redInactive;
    [Header("Green")]
    [SerializeField] GameObject greenActive;
    [SerializeField] GameObject greenInactive;
    [Header("Blue")]
    [SerializeField] GameObject blueActive;
    [SerializeField] GameObject blueInactive;

    PlayerColor playerColor;
    void Start()
    {
        playerColor = FindFirstObjectByType<PlayerColor>();
    }

    void Update()
    {
        RedSwitcher();
        GreenSwitcher();
        BlueSwitcher();
    }

    void RedSwitcher()
    {
        if (playerColor.GetRedBool())
        {
            redActive.SetActive(true);
            redInactive.SetActive(false);
        }
        else
        {
            redActive.SetActive(false);
            redInactive.SetActive(true);
        }
    }

    void GreenSwitcher()
    {
        if (playerColor.GetGreenBool())
        {
            greenActive.SetActive(true);
            greenInactive.SetActive(false);
        }
        else
        {
            greenActive.SetActive(false);
            greenInactive.SetActive(true);
        }
    }

    void BlueSwitcher()
    {
        if (playerColor.GetBlueBool())
        {
            blueActive.SetActive(true);
            blueInactive.SetActive(false);
        }
        else
        {
            blueActive.SetActive(false);
            blueInactive.SetActive(true);
        }
    }
}
