using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class projectilequeue : MonoBehaviour
{
    public GameObject prefag;
    [SerializeField] internal Queue<GameObject> queue = new Queue<GameObject>(); 


    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            Instantiator();
        }
    }

    private void Instantiator()     
    {
        GameObject projectile = Instantiate(prefag, transform);
        queue.Enqueue(projectile);
        projectile.SetActive(false);
    }

    internal void Remove() 
    {
        GameObject projectile = queue.Dequeue();
        projectile.SetActive(true);
    }

    internal void Add(GameObject projectile, Transform towerposition)
    {
        queue.Enqueue(projectile);
        projectile.transform.position = towerposition.position;
        projectile.SetActive(false);
    }
}