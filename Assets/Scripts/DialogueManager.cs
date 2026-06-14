using UnityEngine;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] List<GameObject> panels = new List<GameObject>();

    int currentPanel;
    void Start()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            panels[i].SetActive(false);
        }
    }

    public void DialogueBeforeChase()
    {        
        panels[currentPanel].SetActive(true);        
    }

    public void NextButtonPressed()
    {
        currentPanel++;
        panels[currentPanel].SetActive(true);
    }
}
