using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    //Start Pos of cur Object
    private float startPos;

    //priv in code or public for click and drop
    public GameObject cam;

    //Show Fields in Editor without it being public
    [SerializeField] private float parallaxEffect = 1;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        //Only need sideways pos
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (cam.transform.position.x * parallaxEffect);
        // x start und distance
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
