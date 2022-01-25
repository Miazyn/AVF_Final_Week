using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Detector : MonoBehaviour
{
    [SerializeField] private LayerMask platformslayerMask;
    public Transform player;
    public bool check;
    private BoxCollider2D boxCollider2d;
    // Update is called once per frame
    void Start()
    {
        platformslayerMask = LayerMask.GetMask("Platform");
        boxCollider2d = gameObject.GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if(isGrounded() == false)
        {
            check = false;
        }
        if(check != true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, .125f);

            if(hit.collider != null)
            {
                if (hit.collider.CompareTag("MovingPlatform"))
                {
                    player.SetParent(hit.transform);
                }
                else
                {
                    player.SetParent(null);
                }
                check = true;
            }
        }
    }


    private bool isGrounded()
    {

        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformslayerMask);
        return raycastHit2d.collider != null;

    }
}
