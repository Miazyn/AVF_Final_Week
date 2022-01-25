using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomize : MonoBehaviour
{
    int a;
    //WORKS WITH INT AND FLOATS
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            a = Random.Range(-10, 10);
            Debug.LogError(a);
        }
    }
}
