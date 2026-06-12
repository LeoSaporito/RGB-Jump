using UnityEngine;

public class ChangeHats : MonoBehaviour
{
    [SerializeField] GameObject playerCowboyHat;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickNoHat()
    {
        playerCowboyHat.SetActive(false);
    }
    public void OnClickCowboyHat()
    { 
        playerCowboyHat.SetActive(true);
        
    }
}
