using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float speed = 20f;
    public GameObject player;
    public GameObject yCoordinate, yCoordinateBelow;

    public float xPos, yPos, zPos, xOffset,yOffset;
    public Vector3 playerMovement;

    public float yOffsetJumping;
    public float yOffsetJumpingHigher;

    //PLATFORM
    public float yOffsetSaved;
    public float platformOffset;
    void Start()
    {
        player = GameObject.Find("Player");
        yCoordinate = GameObject.Find("Y_Coordinate");
        yCoordinateBelow = GameObject.Find("Y_Coordinate_Below");

        xOffset = 2.7f;
        yOffset = 2f;

        yOffsetSaved = yOffset;

        platformOffset = yOffset + ManagerVariables.platformY * 20f;

        yOffsetJumping = yOffset + (yOffset * 0.15f);
        yOffsetJumpingHigher = yOffset + (yOffset * 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //On Platform
        if(ManagerVariables.OnPlatform && !ManagerVariables.OnFloorTop)
        {
            platformOffset = ManagerVariables.platformY * -12f;
            yOffset = platformOffset;
            
        }
        //On floor
        if (!ManagerVariables.OnPlatform && ManagerVariables.OnFloorTop)
        {
            yOffset = yOffsetSaved;
        }
        
        yOffsetJumping = yOffset + (yOffset * 0.15f);
        yOffsetJumpingHigher = yOffset + (yOffset * 0.25f);
        */
        //Reihenfolge -> Jump Nein? -> Jump Ja? -> HöherSprung Ja?  
        //EVTL WEITERFÜHRUNG -> Höheres Level Ja? Jump Höher Ja? Jump Höher Höher Ja?
        if (ManagerVariables.IsRespawning)
        {
            ManagerVariables.IsCamUp = true;
            ManagerVariables.IsCamDown = false;
        }
        if (yCoordinateBelow != null && (ManagerVariables.IsCamDown && !ManagerVariables.IsCamUp))
        {
            
             xPos = player.transform.position.x + xOffset;
             yPos = yCoordinateBelow.transform.position.y + yOffset;
            
            /* PLAYRT JUMP
             *  * if (ManagerVariables.IsPlayerJumping == false || ManagerVariables.IsPlayerJumpingHigher == false)
        {}
            if (ManagerVariables.IsPlayerJumping)
            {

                xPos = player.transform.position.x + xOffset;
                yPos = yCoordinateBelow.transform.position.y + yOffsetJumping;
            }
            if (ManagerVariables.IsPlayerJumpingHigher)
            {
                xPos = player.transform.position.x + xOffset;
                yPos = yCoordinateBelow.transform.position.y + yOffsetJumpingHigher;
            }
            */
        }
        else if(yCoordinate == null)
        {
            Debug.LogError("No y below defined");
        }

        if (yCoordinate != null && (!ManagerVariables.IsCamDown && ManagerVariables.IsCamUp))
        {
            //Positions
            
                xPos = player.transform.position.x + xOffset;
                yPos = yCoordinate.transform.position.y + yOffset;
            
        /* PLAYRT JUMP
         * if (ManagerVariables.IsPlayerJumping == false || ManagerVariables.IsPlayerJumpingHigher == false)
        {}
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
        */
    }
    //Movement
    playerMovement = new Vector3(xPos, yPos, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, playerMovement, Time.deltaTime * speed);

       
    }


}
