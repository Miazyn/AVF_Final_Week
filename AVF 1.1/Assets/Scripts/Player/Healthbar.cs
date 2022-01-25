using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Healthbar : MonoBehaviour
{
    #region[Healthbar Objects]
    private GameObject one_Bar;
    private GameObject two_Bar;
    private GameObject three_Bar;
    #endregion

    private SceneManager sceneManager;
    private Scene scene;

    public GameObject respawn;
    public GameObject you_died;


    //FLash
    private SpriteRenderer player;
    private Material originalMaterial;

    public Material flashMaterial;
    public float time = 0.2f;


    void Start()
    {
        ManagerVariables.IsRespawning = false;


        one_Bar = GameObject.Find("battery_full");
        two_Bar = GameObject.Find("battery_2");
        three_Bar = GameObject.Find("battery_3");

        ManagerVariables.playerDamage = 0;

        respawn.SetActive(false);
        you_died.SetActive(false);

        scene = SceneManager.GetActiveScene();

        //Flash
        player = gameObject.GetComponent<SpriteRenderer>();
        originalMaterial = player.material;
    }

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
            ManagerVariables.IsDeathZone = true;
            ManagerVariables.HasPlayerDied = true;
            RespawnPlayer();
        }
        #endregion

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
        if(col2.gameObject.CompareTag("Enemy_Multi"))
        {
            ManagerVariables.HasTriggerMs = false;
            MultiShot_Enemy.HasSurvived = true;

            TakeDamage(2);
        }
        if (col2.gameObject.gameObject.CompareTag("Enemy") || col2.gameObject.gameObject.CompareTag("Normal_Enemy"))
        {
            TakeDamage(3);
            HealthUpdate();
        }

        if (col2.gameObject.CompareTag("Life"))
        {

            Destroy(col2.gameObject);
            HealthGained();
            
        }
        if (col2.gameObject.CompareTag("Hindernis"))
        {
           // Destroy(col2.gameObject);
            TakeDamage(1);

            
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
