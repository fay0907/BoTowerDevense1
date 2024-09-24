using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        Destroy(gameObject, 5f);
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tower"))
        {
            Debug.Log("Hit Player!");
            Destroy(gameObject);
        }
    }
}
