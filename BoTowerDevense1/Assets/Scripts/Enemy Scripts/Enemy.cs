using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public GameObject projectilePrefab; 
    public Transform firePoint; 

    private float fireRate = 2f; 
    private float nextFireTime = 0f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Tower").transform;
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        if (Time.time > nextFireTime)
        {
            ShootProjectile();
            nextFireTime = Time.time + fireRate;
        }
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.SetDirection((player.position - transform.position).normalized);
        }
    }
}
