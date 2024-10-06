using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    private atak tower;
    private GameObject enemy;
    private enemystats stats;
    private Transform position;
    private projectilequeue queue;
    // Start is called before the first frame update
    void Awake()
    {
        tower = GetComponentInParent<atak>();
        queue = GetComponentInParent<projectilequeue>();
    }
    private void OnEnable()
    {
        enemy = tower.enemyreference();
        stats = enemy.GetComponent<enemystats>();
        position = enemy.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, position.position, 15 * Time.deltaTime);
        }
        else
        {
            queue.Add(gameObject, tower.gameObject.transform);
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == enemy)
        {
            stats.hp -= tower.damage;
            stats.deathcheck();
            queue.Add(gameObject, tower.gameObject.transform);
        }
    }
}