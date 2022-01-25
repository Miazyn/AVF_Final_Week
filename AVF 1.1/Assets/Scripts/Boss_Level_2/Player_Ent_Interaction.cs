using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ent_Interaction : MonoBehaviour
{
    GameObject ent;
    // Start is called before the first frame update
    void Start()
    {
        ent = GameObject.Find("Ent_Gegner");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == ent)
        {
            Debug.LogError("Hit Ent");
        }
    }
}
