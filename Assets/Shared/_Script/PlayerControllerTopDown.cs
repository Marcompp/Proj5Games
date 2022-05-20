using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTopDown : MonoBehaviour
{
    public float speed;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.zero;
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        if (hAxis < -0.1)
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
        else if (hAxis > 0.1)
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

        if (vAxis > 0.1)
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
        else if (vAxis < -0.1)
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }

        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);

        GetComponent<Rigidbody2D>().velocity = speed * dir;
    }
}
