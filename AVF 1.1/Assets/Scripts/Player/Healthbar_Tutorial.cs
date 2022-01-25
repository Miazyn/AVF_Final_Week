using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar_Tutorial : MonoBehaviour
{
    private GameObject one_Bar;
    private GameObject two_Bar;
    private GameObject three_Bar;


    private GameObject respawn;
    private GameObject you_died;
    //FLash
    private SpriteRenderer player;
    private Material originalMaterial;

    public Material flashMaterial;
    public float time = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        ManagerVariables.IsRespawning = false;

        one_Bar = GameObject.Find("battery_full");
        two_Bar = GameObject.Find("battery_2");
        three_Bar = GameObject.Find("battery_3");

        respawn = GameObject.Find("DeathScreen");
        you_died = GameObject.Find("You_Died");

        ManagerVariables.playerDamage = 0;

        respawn.SetActive(false);
        you_died.SetActive(false);

        //Flash
        player = gameObject.GetComponent<SpriteRenderer>();
        originalMaterial = player.material;
    }

    // Update is called once per frame
    void Update()
    {

        HealthUpdate();
        

    }

    void HealthUpdate()
    {

        if (ManagerVariables.playerDamage == 1)
        {
            one_Bar.SetActive(false);
        }
        if (ManagerVariables.playerDamage == 2)
        {
            one_Bar.SetActive(false);
            two_Bar.SetActive(false);
        }
        #region[Death occured]
        if (ManagerVariables.playerDamage == 3)
        {
            one_Bar.SetActive(false);
            two_Bar.SetActive(false);
            three_Bar.SetActive(false);

            ManagerVariables.HasPlayerDied = true;
            ManagerVariables.IsDeathZone = true;
            RespawnPlayer();
        }
        #endregion

    }



    void HealthGained()
    {

        if (ManagerVariables.playerDamage == 0)
        {

        }
        if (ManagerVariables.playerDamage == 1)
        {
            one_Bar.SetActive(true);
            two_Bar.SetActive(true);
            three_Bar.SetActive(true);
            ManagerVariables.playerDamage -= 1;
        }
        if (ManagerVariables.playerDamage == 2)
        {
            two_Bar.SetActive(true);
            three_Bar.SetActive(true);
            ManagerVariables.playerDamage -= 1;
        }

    }

    void RespawnPlayer()
    {
        respawn.SetActive(true);
        you_died.SetActive(true);

        if (Input.GetButtonDown("Fire1"))
        {
            //For now reload world
            //SceneManager.LoadScene(scene.name);
            respawn.SetActive(false);
            you_died.SetActive(false);

            one_Bar.SetActive(true);
            two_Bar.SetActive(true);
            three_Bar.SetActive(true);

            ManagerVariables.playerDamage = 0;

            ManagerVariables.IsRespawning = true;
        }
    }
    #region[Damage Detected - EFFEKT]
    void TakeDamage(int dmg)
    {
        //Damage not over 3?
        if (ManagerVariables.playerDamage + dmg < 3)
        {
            ManagerVariables.playerDamage += dmg;
        }
        //Damage over 3 set to 3
        else
        {
            ManagerVariables.playerDamage = 3;
        }

        //Play Damage effect!
        player.material = flashMaterial;
        Invoke("Flash", 0.2f);

    }
    void Flash()
    {
        player.material = originalMaterial;
    }
    #endregion

    void OnCollisionEnter2D(Collision2D col2)
    {


        if (col2.gameObject.gameObject.CompareTag("Enemy") || col2.gameObject.gameObject.CompareTag("Normal_Enemy"))
        {
            TakeDamage(3);
            HealthUpdate();
        }

        if (col2.gameObject.CompareTag("Life"))
        {


            HealthGained();

        }
        if (col2.gameObject.CompareTag("Hindernis"))
        {

            TakeDamage(1);
           // Destroy(col2.gameObject);

        }

        if (col2.gameObject.CompareTag("DeathZone"))
        {
            ManagerVariables.IsDeathZone = true;
            TakeDamage(3);
            HealthUpdate();

        }
        HealthUpdate();
    }
}
