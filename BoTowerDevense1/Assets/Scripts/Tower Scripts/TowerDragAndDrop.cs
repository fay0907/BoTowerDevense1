using UnityEngine;
public class TowerDragandDrop : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
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
        if (Input.mousePosition.x > 350 || Input.mousePosition.y > 250) { isDraggable = false; aaa.mouseHasTower = false; }
        print(Input.mousePosition.y);
        //TowerButton.mouseHasTower = false;
    }
}