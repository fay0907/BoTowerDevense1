using UnityEngine;

public class TowerButton : MonoBehaviour
{
    [SerializeField] private GameObject[] towers;
    public bool mouseHasTower = false;

    public void Tower(int towerNumber)
    {
        if (!mouseHasTower)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Instantiate(towers[towerNumber], mousePosition, Quaternion.identity);
            mouseHasTower = true;
            Debug.Log("blaasssss");
        }
    }
}
