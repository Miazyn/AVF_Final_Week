using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public List<Transform> waypoints;
    public float moveSpeed;
    public int target;
    // Update is called once per frame
    void Update()
    {
        //received
        transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, moveSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        //use data, after Update
        if(transform.position == waypoints[target].position)
        {
            //go back and forth
            if(target == waypoints.Count-1)
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
