using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Script : MonoBehaviour
{

    [SerializeField] public GameObject how_to_jump, double_jump, how_to_collect, shoot_the_target,ende_des_level,shoot_again;
    [SerializeField] public GameObject tutorial;

   public GameObject you_died;
    // Start is called before the first frame update
    void Start()
    {
       
        
        how_to_jump = GameObject.Find("How_To_Jump");
        double_jump = GameObject.Find("Double_Jump");
        how_to_collect = GameObject.Find("How_To_Collect");
        shoot_the_target = GameObject.Find("Shoot_The_Target");
        shoot_again = GameObject.Find("Shoot_The_Target_Again");
        ende_des_level = GameObject.Find("Ende_Des_Level");
        
        tutorial.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (you_died.activeSelf)
        {

            ManagerVariables.InTutorial_Jump = false;
            ManagerVariables.InTutorial_DoubleJump = false;
            ManagerVariables.InTutorial_Collect = false;
            ManagerVariables.InTutorial_Shoot = false;
            ManagerVariables.InTutorial_ShootAgain = false;

            how_to_jump.SetActive(true);
            double_jump.SetActive(true);
            how_to_collect.SetActive(true);
            shoot_the_target.SetActive(true);
            shoot_again.SetActive(true);

            tutorial.gameObject.SetActive(false);

        }
        if (ManagerVariables.InTutorial == false)
        {
            if (ManagerVariables.InTutorial_Jump == false && ManagerVariables.InTutorial_DoubleJump == false && ManagerVariables.InTutorial_Collect == false && ManagerVariables.InTutorial_Shoot == false && ManagerVariables.InTutorial_ShootAgain == false)
            {
                tutorial.gameObject.SetActive(false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if(col.gameObject == how_to_jump)
        {
            ManagerVariables.InTutorial_Jump = true;

            col.gameObject.SetActive(false);

            tutorial.gameObject.SetActive(true);

            tutorial.gameObject.GetComponent<Text>().text = "Press D to Jump";
          
           
        }
        if (col.gameObject == double_jump)
        {
            ManagerVariables.InTutorial_DoubleJump = true;

            col.gameObject.SetActive(false);
            tutorial.gameObject.SetActive(true);

            tutorial.gameObject.GetComponent<Text>().text = "Press D twice for a double jump";

           
            
        }

        if (col.gameObject == how_to_collect)
        {
            ManagerVariables.InTutorial_Collect = true;

            col.gameObject.SetActive(false);
            tutorial.gameObject.SetActive(true);

            tutorial.gameObject.GetComponent<Text>().text = "A volleyball! Collect it!";
           
            
        }

        if (col.gameObject == shoot_the_target)
        {
            ManagerVariables.InTutorial_Shoot = true;

            col.gameObject.SetActive(false);
            tutorial.gameObject.SetActive(true);

            tutorial.gameObject.GetComponent<Text>().text = "Shoot the Target! Press A";
            
        }

        if (col.gameObject == shoot_again)
        {
            ManagerVariables.InTutorial_ShootAgain = true;

            col.gameObject.SetActive(false);
            tutorial.gameObject.SetActive(true);

            tutorial.gameObject.GetComponent<Text>().text = "Try that again! Press A";

        }

        if (col.gameObject == ende_des_level)
        {
            ManagerVariables.InTutorial = true;


            
            tutorial.gameObject.SetActive(true);

            tutorial.gameObject.GetComponent<Text>().text = "Nice Job, you finished the tutorial. Now venture on.";
            ManagerVariables.IsTutorialFinished = true;
            
        }




    }
}
