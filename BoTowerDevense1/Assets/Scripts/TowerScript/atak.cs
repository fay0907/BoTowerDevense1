using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atak : MonoBehaviour
{
    private List<GameObject> enemies = new List<GameObject>();
    projectilequeue pool;
    private float atkspd = 1;
    internal int damage = 1;
    internal int range = 5;
    private bool attackcheck = false;
    // Start is called before the first frame update
    void Start()
    {
        pool = GetComponent<projectilequeue>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemies.Add(collision.gameObject);
            if (!attackcheck)
            {
                StartCoroutine(attack());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("colide");
        if (enemies.Contains(collision.gameObject))
        {
            enemies.Remove(collision.gameObject);
        }
    }
    private IEnumerator attack()
    {
        attackcheck = true;

        while (enemies.Count > 0)
        {
            // Check if the first enemy is null (i.e. if it dies)
            if (enemies[0] == null)
            {
                enemies.RemoveAt(0);
                continue; // Skip to the next iteration
            }

            pool.Remove();

            yield return new WaitForSeconds(atkspd);
        }

        attackcheck = false;
    }
    internal GameObject enemyreference() // enemy reference for access in different scripts
    {
        return enemies[0];
    }
}