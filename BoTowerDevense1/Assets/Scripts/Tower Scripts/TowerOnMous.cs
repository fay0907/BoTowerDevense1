using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerOnMous : MonoBehaviour
{
    [SerializeField] private GameObject[] towers;
    public bool mouseHasTower = false;

    public void Tower(int towerNumber)
    {
        if (!mouseHasTower)
        {
            mouseHasTower  = true;
            Instantiate(towers[towerNumber]);
        }
    }
}
