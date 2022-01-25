using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShot_Enemy : MonoBehaviour
{
    public int max_health = 3;
    private int cur_health;
    public static bool HasDiedMs, HasSurvived;

    private SpriteRenderer enemy;
    private Material originalMats;
    public Material flashMats;

    public Animator animator;

    public float deathAnimation = 0.5f;
    public float HasAnimationPlayed = 0f;
    void Start()
    {
        enemy = gameObject.GetComponent<SpriteRenderer>();
        originalMats = enemy.material;

        ManagerVariables.ms_shots_needed = max_health;
        cur_health = ManagerVariables.ms_shots_needed;
    }

    // Update is called once per frame
    void Update()
    {
        if(ManagerVariables.ms_shots_needed == cur_health -1)
        {
            enemy.material = flashMats;
            Invoke("Damage", 0.2f);
        }

        if (ManagerVariables.HasTriggerMs == false)
        {
            if (HasDiedMs)
            {
                Die();
            }
            if (HasSurvived)
            {
                Die();
            }
            
        }
    }
    void Damage()
    {
        enemy.material = originalMats;
    }
    void Die()
    {
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        HasAnimationPlayed = Time.timeSinceLevelLoad;
        animator.SetBool("HasDied", true);
        if (Time.timeSinceLevelLoad - HasAnimationPlayed > deathAnimation)
        {
            Destroy(gameObject);
        }
    }
    
    void OnCollisionEnter2D (Collision2D col)
    {



    }
}
