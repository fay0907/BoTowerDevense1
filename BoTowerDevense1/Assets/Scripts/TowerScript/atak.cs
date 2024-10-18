using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atak : MonoBehaviour
{
    private List<GameObject> enemies = new List<GameObject>();
    projectilequeue pool;
    public float atkspd = 1;
    public int damage = 10;
    public int range = 5;
    private int moneyadded = 10;
    private bool attackcheck = false;

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

            if (enemies[0] == null)
            {
                enemies.RemoveAt(0);
                continue; 
            }
            Money.moneyvalue += moneyadded;
            pool.Remove();

            yield return new WaitForSeconds(atkspd);
        }

        attackcheck = false;
    }
    internal GameObject enemyreference() 
    {
        return enemies[0];
    }
}