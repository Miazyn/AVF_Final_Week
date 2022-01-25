using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Death_Jumped : MonoBehaviour
{
    public Animator animator;
    bool HasDied;
    void Start()
    {
        HasDied = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (HasDied)
        {
            DeathAnimation();
        }
    }

    void DeathAnimation()
    {
        animator.SetBool("HasDied", HasDied);
        float startAnimation = Time.timeSinceLevelLoad;
        if(Time.timeSinceLevelLoad - startAnimation > 0.5f)
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            HasDied = true;
        }

    }
}
