using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage = 10f;
    public float attackRange = 1.5f;
    public float moveSpeed = 3f;

    public GameObject bulletPrefab;  
    public Transform firePoint;      
    public float bulletSpeed = 5f;

    private GameObject target;
    private bool isAttacking = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("cat");
        Debug.Log("Target gevonden");
    }

    void Update()
    {
        if (target != null)
        {
            MoveTowardsTarget();

            float distanceToTarget = Vector2.Distance(transform.position, target.transform.position);
            if (distanceToTarget <= attackRange && !isAttacking)
            {
                isAttacking = true;
                ShootAtTarget();
                Debug.Log("Aan het aanvallen");
            }
        }
    }

    void MoveTowardsTarget()
    {
        Vector3 direction = (target.transform.position - transform.position);
       // transform.position = transform.position + direction * moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }


    void ShootAtTarget()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Vector2 direction = ((Vector2)target.transform.position - (Vector2)firePoint.position).normalized;

        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        Invoke("ResetAttack", 1f);
    }

    void ResetAttack()
    {
        isAttacking = false;
        Debug.Log("Niet aan het aanvallen");
    }
}
