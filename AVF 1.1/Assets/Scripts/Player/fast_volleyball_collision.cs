using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fast_volleyball_collision : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float volleyball_speed = 4f;
    public int volleyBallDamage = 1;
    public float force = 20f;

    public float minFlight = 2f;
    public float timeHeld = 0;


    // Start is called before the first frame update
    void Start()
    {
        timeHeld = Time.timeSinceLevelLoad;

        rb2d = gameObject.GetComponent<Rigidbody2D>();

        rb2d.velocity = new Vector2(1, 0).normalized * volleyball_speed;
        rb2d.AddForce(transform.right * force);
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeSinceLevelLoad - timeHeld > minFlight)
        {
            Destroy(gameObject);
        }
        if(ManagerVariables.HasTriggerMs == false)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {


        /*Enemy enemy = col.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(volleyBallDamage);
        }
        */
        if (col.CompareTag("Player"))
        {
        }
        else if (col.CompareTag("Target"))
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("FastVolleyBall"))
        {
        }
        else if (col.gameObject.CompareTag("Enemy_Multi"))
        {
            ManagerVariables.ms_shots_needed -= 1;
            Destroy(gameObject);
        }
        
        else
        {
            Destroy(gameObject);
        }


    }
}


