using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanalButton : MonoBehaviour
{
    [SerializeField] private string text;
    private GameObject menuPanel;

    void Start()
    {
        if (menuPanel != null && !menuPanel.activeSelf)
        {
            menuPanel.SetActive(false); // Zorg ervoor dat het menu verborgen is bij de start
        }
    } 
}
