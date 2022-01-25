using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volleyball_Collision : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float volleyball_speed = 4f;
    public int volleyBallDamage= 2;
    public float force = 10f;

    public float minFlight = 5f;
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
        
        if(Time.timeSinceLevelLoad - timeHeld > minFlight)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        Enemy enemy = col.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(volleyBallDamage);
            Destroy(gameObject);
        }
        else if (col.CompareTag("Player"))
        {
        }
        else if (col.CompareTag("Target"))
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
            //ManagerVariables.HitTarget = true;
        }
        else if (col.CompareTag("Volleyball_Shoot"))
        {
        }
        else if (col.gameObject.CompareTag("Enemy_Multi"))
        {
            ManagerVariables.ms_shots_needed -= volleyBallDamage;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


        }
}
