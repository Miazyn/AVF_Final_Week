using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managing_Collision_Respawn : MonoBehaviour
{
    public GameObject hindernis;
    public GameObject items;
    // Start is called before the first frame update
    void Start()
    {
        hindernis = GameObject.Find("Objects");
        items = GameObject.Find("Items");
    }

    // Update is called once per frame
    void Update()
    {
        if (ManagerVariables.IsRespawning)
        {
            if (hindernis != null)
            {
                for (int a = 0; a < hindernis.transform.childCount; a++)
                {

                    hindernis.transform.GetChild(a).gameObject.SetActive(true);

                }
            }
            else
            {
                Debug.LogError("No Objects Over Class defined");
            }
            if (items != null)
            {
                for (int b = 0; b < items.transform.childCount; b++)
                {
                    items.transform.GetChild(b).gameObject.SetActive(true);
                }
            }
            else
            {
                Debug.LogError("No Items Over Class defined");
            }
        }
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.CompareTag("Hindernis"))
        {
            col.gameObject.SetActive(false);
        }
        if (col.gameObject.CompareTag("Volleyball_Collect"))
        {
            col.gameObject.SetActive(false);
        }
        if (col.gameObject.CompareTag("Life"))
        {
            col.gameObject.SetActive(false);
        }
    }
}
