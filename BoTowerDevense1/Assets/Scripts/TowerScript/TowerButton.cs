using UnityEngine;

public class TowerButton : MonoBehaviour
{
    [SerializeField] private GameObject[] towers;
    [SerializeField] int towercost;
    public bool mouseHasTower = false;

    public void Tower(int towerNumber)
    {
        if (!mouseHasTower)
        {
            Money.moneyvalue -= towercost;
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Instantiate(towers[towerNumber], mousePosition, Quaternion.identity);
            mouseHasTower = true;
        }
    }
}
