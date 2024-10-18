using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class enemystats : MonoBehaviour
{
    private Transform target;
    private int monnyremoved = 10;
    public int hp = 2;
    public int speed = 6;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Vis").transform;
        if (target == null)
        {
            Debug.Log("Vis Gevonden.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Vis")
        {
            Money.moneyvalue -= monnyremoved;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    internal void deathcheck()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}