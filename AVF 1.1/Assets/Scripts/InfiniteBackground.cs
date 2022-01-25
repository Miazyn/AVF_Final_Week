using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    Vector3 originalPosition;

    private float length;
    //Start Pos of cur Object
    private float originalStartPos;
    private float startPos;
    //priv in code or public for click and drop
    public GameObject cam;
    public GameObject camPos;
    //Show Fields in Editor without it being public
    [SerializeField] private float parallaxEffect = 0.02f;


    // Start is called before the first frame update
    void Start()
    {
        originalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        cam = GameObject.Find("Main Camera");
        //Only need sideways pos
        startPos = transform.position.x;
        originalStartPos = startPos;
        length = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (ManagerVariables.IsRespawning == false && ManagerVariables.IsDeathZone == false)
        {
            // -1 cur position
            float temp = (cam.transform.position.x * (1 - parallaxEffect));
            float distance = (cam.transform.position.x * parallaxEffect) * 0.2f;
            // x start und distance
            transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

            if (temp > startPos + length)
            {
                startPos += length;
            }
            //Opposite question for left movement
        }
        if( ManagerVariables.IsDeathZone)
        {
            startPos = originalStartPos;
            transform.position = originalPosition;

        }
        if (ManagerVariables.IsRespawning)
        {
            startPos = originalStartPos;
            transform.position = originalPosition;
        }
    }
}
