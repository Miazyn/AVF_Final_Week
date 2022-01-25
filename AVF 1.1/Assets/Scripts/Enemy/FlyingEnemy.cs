using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public int health = 6;

    public List<Transform> waypoints;
    public float moveSpeed;
    public int target;
    // Start is called before the first frame update
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
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, moveSpeed * Time.deltaTime);
    }
    void FixedUpdate()
    {
        //use data, after Update
        if (transform.position == waypoints[target].position)
        {
            //go back and forth
            if (target == waypoints.Count - 1)
            {
                target = 0;
            }
            else
            {
                target += 1;
            }
        }
    }
    
}
