using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fire : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float enemy_fire_speed = 1f;
    public int enemy_fire_damage = 1;

    public float min_flight = 3f;
    public float timeHeld = 0;

    void Start()
    {

        timeHeld = Time.timeSinceLevelLoad;

        rb2d = gameObject.GetComponent<Rigidbody2D>();

        rb2d.velocity = transform.right * -1 * enemy_fire_speed;

    }

    // Update is called once per frame
    void Update()
    {

        if(Time.timeSinceLevelLoad - timeHeld > min_flight)
        {
            Destroy(gameObject);
        }

    }


    void OnTriggerEnter2D(Collider2D col2d)
    {

        Player player = col2d.GetComponent<Player>();

        if (col2d.CompareTag("Enemy"))
        {

        }
        else if (col2d.CompareTag("Player"))
        {
            ManagerVariables.playerDamage += 1;
            Destroy(gameObject);
        }
        else if (col2d.CompareTag("Enemy_Fire") || col2d.CompareTag("Volley_Enemy_Fire")) { 
        }
        else if (col2d.CompareTag("Life")) { }
        else if (col2d.CompareTag("Enemy_Multi")) { }
        else
        {
            Destroy(gameObject);
        }

    }
}