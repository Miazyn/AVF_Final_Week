using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    //respawn
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    public Managing_Collision_Respawn respawnitems;

    public GameObject endeDesLevels;

    //GameStart
    private float curStartTime;
    public float startTime = 2f;
    private float sinceStart = 0;

    //Pegasus not needed time frame
    

    //Trigger Enemy cooldown
    public float minTriggerCooldown = 1.5f;
    private float sinceTrigger = 0;
    private bool HasCooledDown = false;

    private int max_health = 3;

    [SerializeField] private LayerMask platformslayerMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    [Range(1,10)]
    public float jumpVelocity;

    public float fallMultiplier = 2.5f;
    public float jumpReduction = 0.7f;

    public Transform firePoint;
    public GameObject volleyBallPrefab;
    public GameObject infiniteVolleyBallPrefab;

    public float speed = 0.02f;
    private float savedSpeed;
    public float trigger_speed = 0.1f;
    public Animator animator;
    private int firing_times;

    private bool  smallJump;
    public int starting_volleyballs = 1;

    //animator Bools etc
     bool IsJumping, IsRunning, HasUnicorn, IsIdle, IsFloor, HasDied, ImZiel;

    void Start()
    {
        respawnitems = gameObject.GetComponent<Managing_Collision_Respawn>();
        sinceStart = Time.timeSinceLevelLoad;
        HasUnicorn = false;
        IsJumping = false;
        IsRunning = false;
        IsIdle = false;
        HasDied = false;
        ImZiel = false;

        boxCollider2d = gameObject.GetComponent<BoxCollider2D>();
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        ManagerVariables.playerDamage = max_health;
        platformslayerMask = LayerMask.GetMask("Platform");

        ManagerVariables.playerDamage = 0;
        ManagerVariables.IsRespawning = false;
        
        smallJump = false;

        curStartTime = startTime;
        savedSpeed = speed;

        HasCooledDown = true;



    ManagerVariables.volleyballs = starting_volleyballs;
    }

    // Update is called once per frame
    void Update()
    {
        if (ManagerVariables.HasPlayerDied)
        {
            ManagerVariables.volleyballs = 0;
        }
        #region[Multi_Shot_Enemy]

        if (ManagerVariables.HasTriggerMs == true)
        {
            if (ManagerVariables.ms_shots_needed != 0)
            {
                if (MultiShot_Enemy.HasDiedMs == false || MultiShot_Enemy.HasSurvived == false)
                {
                    animator.SetBool("IsRunning", false);
                    speed = 0;
                }
               
                if (Input.GetButtonDown("Fire1") && ManagerVariables.volleyballs > 0)
                {
                    Shoot();
                }
            }
            else
            {
                animator.SetBool("IsRunning", true);
                ManagerVariables.HasTriggerMs = false;
                MultiShot_Enemy.HasDiedMs = true;
                HasCooledDown = false;
                sinceTrigger = Time.timeSinceLevelLoad;
                
            }
        }

        if((MultiShot_Enemy.HasDiedMs || MultiShot_Enemy.HasSurvived) && HasCooledDown == false)
        {
            if(minTriggerCooldown < Time.timeSinceLevelLoad - sinceTrigger)
            {
                HasCooledDown = true;
                speed = savedSpeed;
            }
        }

        #endregion
        #region[respawn]
        if (ManagerVariables.IsDeathZone == true)
        {
            player.transform.position = respawnPoint.transform.position;
        }
        if (ManagerVariables.IsRespawning == true)
        {
            
            player.transform.position = respawnPoint.transform.position;


            

            HasUnicorn = false;
            IsJumping = false;
            IsRunning = false;
            IsIdle = false;
            HasDied = false;
            ImZiel = false;

            respawnitems.ItemRespawn();
            ManagerVariables.IsRespawning = false;
            ManagerVariables.IsDeathZone = false;
            startTime = (Time.timeSinceLevelLoad - sinceStart) + curStartTime;
            speed = savedSpeed;
            ManagerVariables.HasPlayerDied = false;
        }
        #endregion
        if (Time.timeSinceLevelLoad - sinceStart > startTime)
        {
            
            IsIdle = false;
            #region[IsPlayerAlive Is True]
            if (ManagerVariables.playerDamage != 3)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                if(ManagerVariables.InTutorial_Jump || ManagerVariables.InTutorial_DoubleJump || ManagerVariables.InTutorial_Collect  || ManagerVariables.InTutorial_Shoot || ManagerVariables.InTutorial_ShootAgain)
                {
                    speed = savedSpeed * 0.5f;
                    Tutorial();
                }
                #region[saved speed set to speed]
                if (ManagerVariables.HasTriggerMs == false && ManagerVariables.InTutorial_Jump == false && ManagerVariables.InTutorial_DoubleJump == false && ManagerVariables.InTutorial_Collect == false && ManagerVariables.InTutorial_Shoot == false && ManagerVariables.InTutorial_ShootAgain == false)
                {
                    speed = savedSpeed;
                }
                #endregion

                if (isGrounded())
                {
                    //condi:
                    IsJumping = false;
                    IsRunning = true;
                    //Floor but not jumped

                    ManagerVariables.IsPlayerJumping = false;
                    ManagerVariables.IsPlayerJumpingHigher = false;
                }
                #region [Jump]

                

                if (isGrounded() != true)
                {
                    if (!HasUnicorn)
                    {
                        IsJumping = true;
                        IsRunning = false;
                    }
                    else
                    {
                        IsRunning = true;
                    }

                    ManagerVariables.IsPlayerJumping = true;
                }
                if(!isGrounded() && smallJump)
                {
                    ManagerVariables.IsPlayerJumpingHigher = true;
                }
                if (isGrounded() && Input.GetButtonDown("Jump"))
                {
                    
                    //condis:
                    IsRunning = false;
                    IsJumping = true;
                    //Big Jump
                    smallJump = false;
                    Jump();


                }
                if (smallJump == false && isGrounded() != true && Input.GetButtonDown("Jump") && !ManagerVariables.HasTriggerMs)
                {
                    //condi
                    
                    if (!HasUnicorn)
                    {
                        IsRunning = false;
                        IsJumping = true;
                    }
                    else
                    {
                        IsRunning = true;
                    }
                    
                    //Jumped and now smaller Jump
                    SmallerJump();
                    smallJump = true;

                }
                if (smallJump == false && isGrounded() != true && Input.GetButtonDown("Jump") && ManagerVariables.HasTriggerMs)
                {
                    //condi
                    
                    if (!HasUnicorn)
                    {
                        IsRunning = false;
                        IsJumping = true;
                    }
                    else
                    {
                        IsRunning = true;
                    }
                    //Jumped and now smaller Jump
                    MSSmallerJump();
                    smallJump = true;

                }

                #endregion
                if (ManagerVariables.volleyballs > 0 && ManagerVariables.HasTriggerMs == false && HasCooledDown)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        Shoot();
                    }
                }

                if (ImZiel)
                {
                    HasUnicorn = false;
                    IsJumping = false;
                    IsRunning = false;
                    IsIdle = true;

                    animator.SetBool("HasUnicorn", HasUnicorn);
                    animator.SetBool("IsJumping", IsJumping);
                    animator.SetBool("IsRunning", IsRunning);
                    animator.SetBool("IsIdle", IsIdle);
                    animator.SetBool("HasDied", HasDied);
                    transform.Translate(0, 0, 0);
                    speed = 0;
                }

            }
            #endregion
            else if (ManagerVariables.playerDamage == 3)
            {
                speed = 0;
                HasUnicorn = false;
                IsJumping = false;
                IsRunning = false;
                transform.Translate(speed, 0, 0);
                HasDied = true;
            }
        }
        else
        {
            IsIdle = true;
        }

        if(rigidbody2d.velocity.y < 0)
        {
            rigidbody2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        //animator:
        animator.SetBool("HasUnicorn", HasUnicorn);
        animator.SetBool("IsJumping", IsJumping);
        animator.SetBool("IsRunning", IsRunning);
        animator.SetBool("IsIdle", IsIdle);
        animator.SetBool("HasDied", HasDied);

    }

    void MSSmallerJump()
    {
        rigidbody2d.velocity = Vector3.right * 0.7f;
    }

    void SmallerJump()
    {
        rigidbody2d.velocity = (Vector2.up * jumpVelocity) * jumpReduction;

        rigidbody2d.velocity += Vector2.right * 0.5f;

    }
    void Jump()
    {

        rigidbody2d.velocity = Vector2.up * jumpVelocity;

        
    }

    void Shoot()
    {

        Instantiate(volleyBallPrefab, firePoint.position, firePoint.rotation);
        ManagerVariables.volleyballs -= 1;

    }

    void Add_Speed()
    {
        trigger_speed += trigger_speed * 0.005f;
    }

    #region[Tutorial]
    void Tutorial()
    {

        if (ManagerVariables.InTutorial_Jump)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                ManagerVariables.InTutorial_Jump = false;
            }
        }
        if (ManagerVariables.InTutorial_DoubleJump)
        {
            if (smallJump == true)
            {
                ManagerVariables.InTutorial_DoubleJump = false;
            }
        }
        if (ManagerVariables.InTutorial_Collect)
        {
            if (ManagerVariables.volleyballs != 0)
            {
                ManagerVariables.InTutorial_Collect = false;
            }
        }
        if (ManagerVariables.InTutorial_Shoot || ManagerVariables.InTutorial_ShootAgain)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                ManagerVariables.InTutorial_Shoot = false;
                ManagerVariables.InTutorial_ShootAgain = false;
            }
        }

       


    }
    #endregion
    private bool isGrounded()
    {

        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformslayerMask);
        
        return raycastHit2d.collider != null;

    }

    void OnCollisionEnter2D(Collision2D col2)
    {

        if (col2.gameObject.CompareTag("Volleyball_Collect"))
        {
            ManagerVariables.volleyballs += 1;

        }
        if (col2.gameObject.CompareTag("Pegasus"))
        {
            HasUnicorn = true;
            //DESTROY
            Destroy(col2.gameObject);
        }
        if (col2.gameObject.CompareTag("Ziel"))
        {
            
           
            ImZiel = true;
            
        }


    }
}

