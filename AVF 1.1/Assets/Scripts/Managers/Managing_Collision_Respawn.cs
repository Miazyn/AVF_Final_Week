using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managing_Collision_Respawn : MonoBehaviour
{
    public GameObject hindernis;
    public GameObject items , gegner, fliegendeGegner;

    GameObject fliegendParent;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ItemRespawn()
    {
        
            Debug.LogError("I am being called");

            if (hindernis != null)
            {
                for (int a = 0; a < hindernis.transform.childCount; a++)
                {

                    hindernis.transform.GetChild(a).gameObject.SetActive(true);
                    Debug.LogError("Set Child active Hindernis");
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
                    Debug.LogError("Set Child active Items");
                }
            }
            else
            {
                Debug.LogError("No Items Over Class defined");
            }
            if (gegner != null)
            {
                for (int b = 0; b < gegner.transform.childCount; b++)
                {
                    gegner.transform.GetChild(b).gameObject.SetActive(true);
                    Debug.LogError("Set Child active Gegner");
                }
            }
            else
            {
                Debug.LogError("No Gegner Over Class defined");
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
        if(col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("Normal_Enemy"))
        {
            col.gameObject.SetActive(false);
        }

        //BOSSES
        //REspawn boss 1 at same location.
        if (col.gameObject.CompareTag("Enemy_Multi"))
        {
            col.gameObject.SetActive(false);
        }
    }
}
