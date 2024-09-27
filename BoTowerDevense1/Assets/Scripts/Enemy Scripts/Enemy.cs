using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage = 10f;
    public float attackRange = 1.5f;
    public float moveSpeed = 3f;

    private GameObject target;
    private bool isAttacking = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Tower");
        Debug.Log("Target gevonden");
    }

    void Update()
    {
        if (target != null)
        {
            MoveTowardsTarget();

            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (distanceToTarget <= attackRange && !isAttacking)
            {
                isAttacking = true;
                AttackTarget();
                Debug.Log("Aan het aanvallen"); //!!
            }
        }
    }

    void MoveTowardsTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void AttackTarget()
    {
        Health targetHealth = target.GetComponent<Health>();

        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
        }

        Invoke("ResetAttack", 1f);
    }

    void ResetAttack()
    {
        isAttacking = false;
        Debug.Log("Niet Aan het aanvallen"); //!!
    }
}
