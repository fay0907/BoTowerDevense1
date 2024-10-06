
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemystats : MonoBehaviour
{
    public int hp = 2;
    public int speed = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    internal void deathcheck() //call after attack logic executes
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}