using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmeraldCollection : MonoBehaviour
{
     GameObject emerald_filled_1, emerald_filled_2, emerald_filled_3;
     GameObject emerald_empty_1, emerald_empty_2, emerald_empty_3;
     GameObject collectEmerald1, collectEmerald2, collectEmerald3;

    public GameObject ende_des_level;

    public GameObject interaction;

    private bool emerald1, emerald2, emerald3;

    //Portal
     GameObject portal_stone_1, portal_stone_2, portal_stone_3;
     GameObject portal_stone_1_2, portal_stone_1_3, portal_stone_2_3;
     GameObject portal_full, portal_empty;

    // Start is called before the first frame update
    void Start()
    {
        //Portal
        //1 Stone
        portal_stone_1 = GameObject.Find("portal_stone_1");
        portal_stone_2 = GameObject.Find("portal_stone_2");
        portal_stone_3 = GameObject.Find("portal_stone_3");
        //2 Stone
        portal_stone_1_2 = GameObject.Find("portal_stone_1_2");
        portal_stone_1_3 = GameObject.Find("portal_stone_1_3");
        portal_stone_2_3 = GameObject.Find("portal_stone_2_3");
        //Full and Empty
        portal_full = GameObject.Find("portal_stone_1_2_3");
        portal_empty = GameObject.Find("portal_stone_empty");

        //
        ende_des_level = GameObject.Find("Ende_Des_Level");

        interaction = GameObject.Find("Interaction");
        emerald_filled_1 = GameObject.Find("Emerald_1_Filled");
        emerald_filled_2 = GameObject.Find("Emerald_2_Filled");
        emerald_filled_3 = GameObject.Find("Emerald_3_Filled");

        emerald_empty_1 = GameObject.Find("Emerald_3_Empty");
        emerald_empty_2 = GameObject.Find("Emerald_2_Empty");
        emerald_empty_3 = GameObject.Find("Emerald_1_Empty");

        collectEmerald1 = GameObject.Find("Jewel_1");
        collectEmerald2 = GameObject.Find("Jewel_2");
        collectEmerald3 = GameObject.Find("Jewel_3");

        emerald1 = false;
        emerald2 = false;
        emerald3 = false;

        emerald_filled_1.SetActive(false);
        emerald_filled_2.SetActive(false);
        emerald_filled_3.SetActive(false);
        if (interaction != null)
        {
            interaction.SetActive(false);
        }
        else
        {
            Debug.LogError("Interaction Not Set");
        }
        //Portal Activity
        //1Stone
        portal_stone_1.SetActive(false);
        portal_stone_2.SetActive(false);
        portal_stone_3.SetActive(false);
        //2 Stone
        portal_stone_1_2.SetActive(false);
        portal_stone_1_3.SetActive(false);
        portal_stone_2_3.SetActive(false);
        //Full or Empty
        portal_full.SetActive(false);
        portal_empty.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        CrystalFilling();
    }

    void CrystalFilling()
    {
       

        emerald_filled_1.SetActive(emerald1);
        emerald_filled_2.SetActive(emerald2);
        emerald_filled_3.SetActive(emerald3);

        //1 Emerald
        if (emerald1 && !emerald2 && !emerald3)
        {
            NullifyEmeralds();
            portal_stone_1.SetActive(true);

        }
        if(emerald2 && !emerald1 && !emerald3)
        {
            NullifyEmeralds();
            portal_stone_2.SetActive(true);
        }
        if(emerald3 && !emerald1 && !emerald2)
        {
            NullifyEmeralds();
            portal_stone_3.SetActive(true);
        }
        //2 Emeralds
        if(emerald1 && emerald2 && !emerald3)
        {
            NullifyEmeralds();
            portal_stone_1_2.SetActive(true);
        }
        if(emerald1 && emerald3 && !emerald2)
        {
            NullifyEmeralds();
            portal_stone_1_3.SetActive(true);
        }
        if(emerald2 && emerald3 && !emerald1)
        {
            NullifyEmeralds();
            portal_stone_2_3.SetActive(true);
        }
        //Full Empty
        if(emerald1 && emerald2 && emerald3)
        {
            NullifyEmeralds();
            portal_full.SetActive(true);
        }
        if(!emerald1 && !emerald2 && !emerald3)
        {
            NullifyEmeralds();
            portal_empty.SetActive(true);
        }
    }

    void NullifyEmeralds()
    {
        //Portal Activity
        //1Stone
        portal_stone_1.SetActive(false);
        portal_stone_2.SetActive(false);
        portal_stone_3.SetActive(false);
        //2 Stone
        portal_stone_1_2.SetActive(false);
        portal_stone_1_3.SetActive(false);
        portal_stone_2_3.SetActive(false);
        //Full or Empty
        portal_full.SetActive(false);
        portal_empty.SetActive(false);
    }

    void Evaluation()
    {

        if(emerald1 && emerald2 && emerald3)
        {
            if (interaction != null)
            {
                interaction.gameObject.GetComponent<Text>().text = "You collected all Emeralds nice.";
                interaction.SetActive(true);
            }
            else
            {
                Debug.LogError("No Interaction Defined");
            }
        }
        else
        {
            if (interaction != null)
            {
                interaction.gameObject.GetComponent<Text>().text = "You did not collect all Emeralds, go back.";

                Invoke("ShowInteraction", 0.2f);
            }
            else
            {
                Debug.LogError("No Interaction Defined");
            }
            ManagerVariables.IsRespawning = true;
        }

    }

    void ShowInteraction()
    {
        interaction.SetActive(true);
        Invoke("HideInteraction", 2f);
    }
    void HideInteraction()
    {
        interaction.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject == collectEmerald1)
        {
            emerald1 = true;
            collectEmerald1.SetActive(false);
        }
        if (col.gameObject == collectEmerald2)
        {
            emerald2 = true;


            collectEmerald2.SetActive(false);
        }
        if (col.gameObject == collectEmerald3)
        {
            emerald3 = true;


            collectEmerald3.SetActive(false);
        }

        if (col.gameObject == ende_des_level)
        {

            Evaluation();

        }


    }
}
