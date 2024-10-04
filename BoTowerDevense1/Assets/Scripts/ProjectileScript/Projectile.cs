using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;  

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower"))
        {
            Health towerHealth = collision.GetComponent<Health>();

            if (towerHealth != null)
            {
                towerHealth.TakeDamage(damage);
            }

            Destroy(gameObject);  
        }
    }
}
