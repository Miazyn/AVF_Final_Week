using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ent_Gegner : MonoBehaviour
{
    public float speed = 2f;
    public GameObject player;
    public GameObject yCoordinate;
    public float increase_speed = 2f;

    public float xPos, yPos, zPos, xOffset, yOffset;
    public float originalPosX, originialPosY, savedspeed,waiting;
    public Vector3 playerMovement;
    bool cooldown;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        yCoordinate = GameObject.Find("Y_Coordinate");

        xOffset = -2.5f;
        yOffset = 1.1f;
        cooldown = true;
        originalPosX = transform.position.x;
        originialPosY = transform.position.y;
        savedspeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        xPos = player.transform.position.x + xOffset;
        yPos = yCoordinate.transform.position.y + yOffset;


        playerMovement = new Vector3(xPos, yPos, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, playerMovement, Time.deltaTime * speed);
        */
        if (!cooldown)
        {
            speed = 0;
            if (Time.timeSinceLevelLoad - waiting > 1f)
            {
                speed = savedspeed;
                cooldown = true;
            }
        }
        if (!ManagerVariables.HasPlayerDied && cooldown)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (ManagerVariables.HasPlayerDied|| ManagerVariables.IsRespawning)
        {
            Debug.LogError("PlayerDead");
            transform.position = new Vector3(originalPosX, originialPosY, transform.position.z);
            
            cooldown = false;

            waiting = Time.timeSinceLevelLoad;

        }

    }
}
