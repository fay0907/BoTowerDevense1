using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class projectilequeue : MonoBehaviour
{
    public GameObject prefag;
    [SerializeField] internal Queue<GameObject> queue = new Queue<GameObject>(); 
    [SerializeField] private AudioSource Meow;
    float timeelapsed;


    void Start()
    {

        Meow = GetComponent<AudioSource>();
        for (int i = 0; i < 6; i++)
        {
            Instantiator();
        }
    }

    private void Instantiator()     
    {
        GameObject projectile = Instantiate(prefag, transform);
        Meow.Play();
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

    private void Update()
    {
        timeelapsed += Time.deltaTime;
        if (timeelapsed > 5)
        {
            Meow.Stop();
            timeelapsed = 0;
        }
    }
}