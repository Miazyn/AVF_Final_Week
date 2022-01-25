using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Enemy_Interaction : MonoBehaviour
{
    [SerializeField]public GameObject trigger_ms_enemy;
    void Start()
    {
        trigger_ms_enemy = GameObject.Find("Trigger_Multi_Shot");

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D (Collision2D col2)
    {

        if(col2.gameObject == trigger_ms_enemy)
        {
            ManagerVariables.HasTriggerMs = true;
            Destroy(col2.gameObject);
        }

    }
}
