using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTopDown : MonoBehaviour
{
    private Animator animator;
    GameManager gm;

    [Space]
    [Header("Atributos:")]
    public float PLAYER_SPEED = 5.0f;
    
    
    [Space]
    [Header("Stats:")]
    public Vector2 dir;
    public float movimentSpeed;

    [Space]
    [Header("Referencias:")]
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject crosshair;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        // Aiming();
        InputFunct();        
    }

    void Aiming(){
        if(dir != Vector2.zero) {
            Debug.Log("Aiming");
            crosshair.SetActive(true);
            crosshair.transform.localPosition = dir;
        }
        else {
            Debug.Log("Aiming");
            crosshair.SetActive(false);
        }
    }

    void InputFunct(){
        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }
    }

    void Moving()
    {
        dir = Vector2.zero;
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
        else
            {
                dir.y = 0;
                dir.x = 0;
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

        GetComponent<Rigidbody2D>().velocity = PLAYER_SPEED * dir;
        movimentSpeed = PLAYER_SPEED * dir.magnitude;
        
    }
}
