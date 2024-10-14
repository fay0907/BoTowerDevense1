using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class enemystats : MonoBehaviour
{
    private Transform target;
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