using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "HatFoundSO", menuName = "HatFoundSO")]
public class HatFoundSO : ScriptableObject
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject hatFound;
    [SerializeField] GameObject notYourHat;
    [SerializeField] TextMeshProUGUI hatFoundText;
    [SerializeField] TextMeshProUGUI notYourHatText;

    public GameObject GetPlayer()
    {
        return player;
    }
    public GameObject GetHatFound()
    {
        return hatFound;
    }
    public GameObject GetNotYourHat()
    {
        return notYourHat;
    }

}
