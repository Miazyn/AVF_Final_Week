using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerVariables : MonoBehaviour
{
    public SceneManager sceneManager;
    public Scene tutorial, levelOne;


    public static int playerDamage;
    public static int volleyballs;
    public static int ms_shots_needed;
    //TutorialLevel
    public static bool IsTutorialFinished;
    public static bool IsRespawning, IsDeathZone, InTutorial, InTutorial_Jump, InTutorial_DoubleJump, InTutorial_Collect, InTutorial_Shoot, InTutorial_ShootAgain;
    //Enemy MS
    public static bool HasTriggerMs;
    public static bool IsPlayerJumping, IsPlayerJumpingHigher, HasPlayerDied;

    public static bool HitTarget;

    //CAM
    public static bool IsCamDown, IsCamUp;
    // Start is called before the first frame update
    void Start()
    {
        IsTutorialFinished = false;
        HasTriggerMs = false;

        IsCamDown = false;
        IsCamUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTutorialFinished)
        {
            Invoke("LevelOne", 0.5f);
        }
    }

    void LevelOne()
    {

        SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
    }
}
