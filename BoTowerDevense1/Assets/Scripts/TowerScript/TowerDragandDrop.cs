using UnityEngine;
public class TowerDragandDrop : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] int towercost;
    private GameObject towerControll;
    private TowerButton aaa;

    bool isDraggable = true;
    // private TowerButton TowerButton;

    private void Start()
    {
        towerControll = GameObject.Find("TowerButtons");
        aaa = towerControll.GetComponent<TowerButton>();
    }
    void Update()
    {

        if (isDraggable)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("test");
        Money.moneyvalue -= towercost;
        if (Input.mousePosition.x > 350 || Input.mousePosition.y > 250) {  isDraggable = false; aaa.mouseHasTower = false;
           //TowerButton.mouseHasTower = false;
        }
    }
}