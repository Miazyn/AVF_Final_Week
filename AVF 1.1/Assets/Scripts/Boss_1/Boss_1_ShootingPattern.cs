using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1_ShootingPattern : MonoBehaviour
{
    public GameObject bullet, volleyball;
    public Transform firePoint;

    public float bulletSpeed = 3f;

    int a;

    float routineTime = 0f;
    float routineDone = 10f;
    bool routineFinished;
    bool firstTime;
    // Start is called before the first frame update
    void Start()
    {
        routineFinished = true;
        routineTime = Time.timeSinceLevelLoad;
        firstTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (((Time.timeSinceLevelLoad - routineTime > routineDone) && routineFinished) || 
            firstTime && (Time.timeSinceLevelLoad - routineTime > 0.5f))
        {
            firstTime = false;
            routineFinished = false;

            Invoke("bulletShoot", 2f);
            Invoke("volleyShoot", 4f);
            Invoke("bulletShoot", 6f);
            Invoke("volleyShoot", 8f);
            Invoke("volleyShoot", 10f);
            routineTime = Time.timeSinceLevelLoad;
            a = Random.Range(1, 3);
            routineFinished = true;
        }

        /*
        if ((Time.timeSinceLevelLoad - routineTime > routineDone) && routineFinished)
        {
            a = Random.Range(1, 3);
            Debug.LogError(a);
            if (a == 1)
            {
                routineFinished = false;
                Invoke("bulletShoot", 1f);
                Invoke("bulletShoot", 2f);
                Invoke("bulletShoot", 3f);
                Invoke("bulletShoot", 4f);
                Invoke("bulletShoot", 5f);
                routineTime = Time.timeSinceLevelLoad;
                a = Random.Range(1, 3);
                routineFinished = true;
            }

            if (a == 2)
            {
                routineFinished = false;
                Invoke("volleyShoot", 1f);
                Invoke("volleyShoot", 2f);
                Invoke("bulletShoot", 3f);
                Invoke("volleyShoot", 4f);
                Invoke("bulletShoot", 5f);
                routineTime = Time.timeSinceLevelLoad;
                a = Random.Range(1, 3);
                routineFinished = true;
            }

            if (a == 3)
            {
                routineFinished = false; 
                Invoke("volleyShoot", 1f);
                Invoke("bulletShoot", 2f);
                Invoke("volleyShoot", 3f);
                Invoke("bulletShoot", 4f);
                Invoke("volleyShoot", 5f);
                routineTime = Time.timeSinceLevelLoad;
                a = Random.Range(1, 3);
                routineFinished = true;
            }
        }*/
    }

    void bulletShoot()
    {
        Debug.LogError("Bullet");
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    void volleyShoot()
    {
        Debug.LogError("Volley");
        Instantiate(volleyball, firePoint.position, firePoint.rotation);
    }
}
