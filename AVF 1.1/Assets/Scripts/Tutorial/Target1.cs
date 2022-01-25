using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target1 : MonoBehaviour
{
    public Animator animator;

    public float startAnimation = 0f;
    public float endAnimation = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ManagerVariables.HitTarget)
        {
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            Destroyed();
            ManagerVariables.HitTarget = false;
        }
    }

    void Destroyed()
    {
        animator.SetBool("IsDestroyed", true);
        startAnimation = Time.timeSinceLevelLoad;
        if(Time.timeSinceLevelLoad-startAnimation > endAnimation)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisonEnter2D(Collision2D col)
    {
        
    }
}
