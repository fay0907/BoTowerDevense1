using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;  

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        Debug.Log(gameObject.name + " took " + damageAmount + " damage. Health remaining: " + health);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " is dead!");
        Destroy(gameObject);  
    }
}
