using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Platforms : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject camdown,camup,camMoveList;

    GameObject curPlatform;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ManagerVariables.IsRespawning)
        {
            ManagerVariables.IsCamDown = false;
            ManagerVariables.IsCamUp = true;
            if(camMoveList != null)
            {
                for(int a = 0; a < camMoveList.transform.childCount; a++)
                {

                    camMoveList.transform.GetChild(a).gameObject.SetActive(true);

                }
            }
            else
            {
                Debug.LogError("Cam Objects not in Cam List");
            }
            camdown.SetActive(true);
            camup.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Side_Of_Platform"))
        {
            Debug.LogError(col.gameObject.transform.position);
            rb.AddForce(Vector3.left * 150f);
        }

        if (col.gameObject.CompareTag("Cam_Down"))
        {
            ManagerVariables.IsCamDown = true;
            ManagerVariables.IsCamUp = false;

            camdown = col.gameObject;
            camdown.SetActive(false);
        }
        if (col.gameObject.CompareTag("Cam_Up"))
        {
            ManagerVariables.IsCamDown = false;
            ManagerVariables.IsCamUp = true;

            camup = col.gameObject;
            camup.SetActive(false);
        }
        if (col.gameObject.CompareTag("Platform_Top"))
        {
            ManagerVariables.OnPlatform = true;
            ManagerVariables.OnFloorTop = false;
            curPlatform = col.gameObject;
            ManagerVariables.platformY = curPlatform.transform.position.y;
            Debug.LogError(curPlatform.transform.position.y);
        }
        if (col.gameObject.CompareTag("Ground_Top"))
        {
            ManagerVariables.OnPlatform = false;
            ManagerVariables.OnFloorTop = true;
            Debug.LogError("floor Top");
        }
    }
}
