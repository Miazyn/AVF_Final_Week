using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerVariables : MonoBehaviour
{
    public LevelLoader levelLoading;
    public Scene tutorial, levelOne;


    public static int playerDamage;
    public static int volleyballs;
    public static int ms_shots_needed;
    //TutorialLevel
    /// FROM LVL TUTO -> LVL 1
    public static bool IsTutorialFinished;

    public static bool IsRespawning, IsDeathZone, InTutorial, InTutorial_Jump, InTutorial_DoubleJump, InTutorial_Collect, InTutorial_Shoot, InTutorial_ShootAgain;
    //Enemy MS
    public static bool HasTriggerMs;
    public static bool IsPlayerJumping, IsPlayerJumpingHigher, HasPlayerDied;

    public static bool HitTarget;

    //CAM
    public static bool IsCamDown, IsCamUp, OnPlatform, OnFloorTop;
    public static float platformY;

    //Level 1
    //LVL 1 -> Boss 1
    public static bool IsLevelOneFinished;
    //Boss 1 -> Lvl 2 = On Defeat... // unclean

    //Level 2 -> Boss 2
    public static bool IsLevelTwoFinished;
    //Boss2 -> Level 3
    public static bool IsBossTwoFinished;

    // Start is called before the first frame update
    void Start()
    {
        IsTutorialFinished = false;
        IsLevelOneFinished = false;
        IsLevelTwoFinished = false;
        IsBossTwoFinished = false;

        HasTriggerMs = false;

        IsCamDown = false;
        IsCamUp = true;

        OnPlatform = false;
        OnFloorTop = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (IsTutorialFinished)
        {
            Invoke("LevelOne", 0.5f);
        }
        if (IsLevelOneFinished)
        {
            Invoke("Level_One_Boss", 0.5f);
        }
        */
    }

    void LevelOne()
    {

        levelLoading.LoadLevel("Level_1");
    }

    void Level_One_Boss()
    {
        levelLoading.LoadLevel("Boss_Shoot");
    }
}
