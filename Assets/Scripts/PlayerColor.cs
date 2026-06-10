using UnityEngine;
using UnityEngine.Device;
using UnityEngine.InputSystem;

public class PlayerColor : MonoBehaviour
{
    bool isRed;
    bool isGreen;
    bool isBlue;

    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();        
    }

    void Update()
    {
        ColourSwitch();
    }

    private void ColourSwitch()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            RedPlayer();
        }
        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            GreenPlayer();
        }
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            BluePlayer();
        }
    }
    void RedPlayer()
    {
        isRed = true;
        isBlue = false;
        isGreen = false;

        sr.color = new Color(255, 0, 0);
    }
    void GreenPlayer()
    {
        isRed = false;
        isBlue = false;
        isGreen = true;

        sr.color = new Color(0, 255, 0);
    }
    void BluePlayer()
    {
        isRed = false;
        isBlue = true;
        isGreen = false;

        sr.color = new Color(0, 0, 255);
    }

    public bool GetRedBool() { return isRed; }
    public bool GetGreenBool() { return isGreen; }
    public bool GetBlueBool() { return isBlue; }
    public SpriteRenderer GetSpriteRenderer() { return sr; }
}
