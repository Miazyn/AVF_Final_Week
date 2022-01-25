using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pegasus : MonoBehaviour
{

    public SpriteRenderer spriteR;
    public Sprite newSprite;
    public Sprite savedSprite;

    //Zeitlich zwischen 10 - 12
    public float min_Pegasus;
    public float timePassed = 0;

    //Waypoint


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad - timePassed > min_Pegasus)
        {

            //Time has run out
            spriteR.sprite = savedSprite;

        }
    }

    void SpriteChange()
    {
        savedSprite = spriteR.sprite;
        spriteR.sprite = newSprite;
        timePassed = Time.timeSinceLevelLoad;
        Debug.LogError(spriteR.sprite);

    }

    void OnCollisionEnter2D(Collision2D col2)
    {

        

    }
}
