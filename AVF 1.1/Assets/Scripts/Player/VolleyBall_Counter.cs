using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolleyBall_Counter : MonoBehaviour
{

    public Text counter;


    void Start()
    {
        counter.text = "0";
    }

    // Update is called once per frame
    void Update()
    {

        counter.text = ManagerVariables.volleyballs.ToString();

    }
}
