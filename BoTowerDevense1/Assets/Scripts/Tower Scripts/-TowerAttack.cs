using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private List<GameObject> enemies = new List<GameObject>();

    private float atkspd = 1;
    internal int damage = 1;
    private bool attackcheck = false;
  
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

            Debug.Log("Attacking");

            // Perform attack logic here

            yield return new WaitForSeconds(atkspd);
        }

        attackcheck = false;
    }
    internal GameObject enemyreference() // enemy reference for access in different scripts
    {
        return enemies[0];
    }
}