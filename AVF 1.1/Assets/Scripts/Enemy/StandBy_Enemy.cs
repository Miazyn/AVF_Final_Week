using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandBy_Enemy : MonoBehaviour
{
    public int health =2;


    void Start()
    {

    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;


        if (health <= 0)
        {

            Die();

        }

    }


    void Die()
    {
        Destroy(gameObject);
    }
}
