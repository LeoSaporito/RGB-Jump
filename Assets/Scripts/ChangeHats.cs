using UnityEngine;

public class ChangeHats : MonoBehaviour
{
    [SerializeField] GameObject playerBeanie;
    [SerializeField] GameObject playerTopHat;
    [SerializeField] GameObject playerCowboyHat;
    [SerializeField] GameObject playerStanPines;
    [SerializeField] GameObject playerSkiMask;
    [SerializeField] GameObject playerNurseHat;
    [SerializeField] GameObject playerSailorHat;
    [SerializeField] GameObject playerMyHat;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickNoHat()
    {
        playerBeanie.SetActive(false);
        playerTopHat.SetActive(false);
        playerCowboyHat.SetActive(false);
        playerStanPines.SetActive(false);
        playerSkiMask.SetActive(false);
        playerNurseHat.SetActive(false);
        playerSailorHat.SetActive(false);
        playerMyHat.SetActive(false);
    }
    public void OnClickBeanie()
    {
        playerBeanie.SetActive(true);

        playerTopHat.SetActive(false);
        playerCowboyHat.SetActive(false);
        playerStanPines.SetActive(false);
        playerSkiMask.SetActive(false);
        playerNurseHat.SetActive(false);
        playerSailorHat.SetActive(false);
        playerMyHat.SetActive(false);
    }
    public void OnClickTopHat()
    {
        playerBeanie.SetActive(false);

        playerTopHat.SetActive(true);

        playerCowboyHat.SetActive(false);
        playerStanPines.SetActive(false);
        playerSkiMask.SetActive(false);
        playerNurseHat.SetActive(false);
        playerSailorHat.SetActive(false);
        playerMyHat.SetActive(false);
    }
    public void OnClickCowboyHat()
    {
        playerBeanie.SetActive(false);
        playerTopHat.SetActive(false);

        playerCowboyHat.SetActive(true);

        playerStanPines.SetActive(false);
        playerSkiMask.SetActive(false);
        playerNurseHat.SetActive(false);
        playerSailorHat.SetActive(false);
        playerMyHat.SetActive(false);
    }
    public void OnClickStanPines()
    {
        playerBeanie.SetActive(false);
        playerTopHat.SetActive(false);
        playerCowboyHat.SetActive(false);

        playerStanPines.SetActive(true);

        playerSkiMask.SetActive(false);
        playerNurseHat.SetActive(false);
        playerSailorHat.SetActive(false);
        playerMyHat.SetActive(false);
    }
    public void OnClickSkiMask()
    {
        playerBeanie.SetActive(false);
        playerTopHat.SetActive(false);
        playerCowboyHat.SetActive(false);
        playerStanPines.SetActive(false);

        playerSkiMask.SetActive(true);

        playerNurseHat.SetActive(false);
        playerSailorHat.SetActive(false);
        playerMyHat.SetActive(false);
    }
    public void OnClickNurseHat()
    {
        playerBeanie.SetActive(false);
        playerTopHat.SetActive(false);
        playerCowboyHat.SetActive(false);
        playerStanPines.SetActive(false);
        playerSkiMask.SetActive(false);

        playerNurseHat.SetActive(true);

        playerSailorHat.SetActive(false);
        playerMyHat.SetActive(false);
    }
    public void OnClickSailorHat()
    {
        playerBeanie.SetActive(false);
        playerTopHat.SetActive(false);
        playerCowboyHat.SetActive(false);
        playerStanPines.SetActive(false);
        playerSkiMask.SetActive(false);
        playerNurseHat.SetActive(false);

        playerSailorHat.SetActive(true);

        playerMyHat.SetActive(false);
    }
    public void OnClickMyHat()
    {
        playerBeanie.SetActive(false);
        playerTopHat.SetActive(false);
        playerCowboyHat.SetActive(false);
        playerStanPines.SetActive(false);
        playerSkiMask.SetActive(false);
        playerNurseHat.SetActive(false);
        playerSailorHat.SetActive(false);

        playerMyHat.SetActive(true);
    }    
}
