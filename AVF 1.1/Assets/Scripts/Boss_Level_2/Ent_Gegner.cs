using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ent_Gegner : MonoBehaviour
{
    public GameObject player;

    public float xPos, yPos;
    public float speed = 10f;
    Vector3 playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        xPos = player.transform.position.x;
        yPos = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement = new Vector3(xPos, yPos, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, playerMovement, Time.deltaTime * speed) ;
    }
}
