using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_Boss_1 : MonoBehaviour
{
    public GameObject exposition;
    // Start is called before the first frame update
    void Start()
    {
        exposition = GameObject.Find("Enemy_Expo");

        exposition.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ManagerVariables.HasTriggerMs)
        {
            exposition.SetActive(true);
        }
    }
}
