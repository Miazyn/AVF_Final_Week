using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ent_Camera : MonoBehaviour
{
    public float speed = 20f;
    public GameObject player;
    public GameObject yCoordinate;

    public float xPos, yPos, zPos, xOffset, yOffset;
    public Vector3 playerMovement;

    public float yOffsetJumping;
    public float yOffsetJumpingHigher;

    void Start()
    {
        player = GameObject.Find("Player");
        yCoordinate = GameObject.Find("Y_Coordinate");

        xOffset = 1f;
        yOffset = 2f;

        yOffsetJumping = yOffset + (yOffset * 0.15f);
        yOffsetJumpingHigher = yOffset + (yOffset * 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        //Reihenfolge -> Jump Nein? -> Jump Ja? -> H�herSprung Ja?  
        //EVTL WEITERF�HRUNG -> H�heres Level Ja? Jump H�her Ja? Jump H�her H�her Ja?
        //Positions
        if (ManagerVariables.IsPlayerJumping == false || ManagerVariables.IsPlayerJumpingHigher == false)
        {
            xPos = player.transform.position.x + xOffset;
            yPos = yCoordinate.transform.position.y + yOffset;
        }
        if (ManagerVariables.IsPlayerJumping)
        {

            xPos = player.transform.position.x + xOffset;
            yPos = yCoordinate.transform.position.y + yOffsetJumping;
        }
        if (ManagerVariables.IsPlayerJumpingHigher)
        {
            xPos = player.transform.position.x + xOffset;
            yPos = yCoordinate.transform.position.y + yOffsetJumpingHigher;
        }

        //Movement
        playerMovement = new Vector3(xPos, yPos, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, playerMovement, Time.deltaTime * speed);


    }


}
