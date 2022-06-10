using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    GameManager gm;
    [SerializeField]
    private float _speed;
    public bool isGrounded;
    [SerializeField]
    private float checkRadius;
    public LayerMask whatIsGroud;
    public bool isFacingRight = false;
    private Vector2 direcao;
    private float dir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        direcao = rb.velocity;
        if(gm.gameState != GameManager.GameState.GAME)
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }
        else
        {
            rb.velocity = direcao;
            rb.isKinematic = false;
            dir = transform.position.x;
            if ((dir <=10f && dir >5f)||(dir >=-10f && dir <-5f)){
                anim.SetBool("attacking",false);
                anim.SetBool("running",true);
                Movement();
            }
            else if(dir<=5f && dir >=-5f){
                anim.SetBool("running",false);
                if(rb.gravityScale>0){
                    anim.SetBool("attacking",true);
                }
            }
            else{
                anim.SetBool("attacking",false);
                anim.SetBool("running",false);
            }
        }
        if(Input.GetAxis("Horizontal")==0.0f){
            rb.velocity -= rb.velocity;
        }
        
    }

    void OnTriggerEnter2D(Object other) {
        if(other.name=="Player"&&rb.gravityScale>0){
            Invoke("LoseLife",0.5f);
        }
    }

    void LoseLife(){
        gm.hp --;
    }

    private void Movement()
    {
        transform.Translate(Vector2.right*dir * _speed * Time.deltaTime, Space.World);
        if(isFacingRight==false && dir>0 && rb.gravityScale>0){
            Flip();
        } else if (isFacingRight == true && dir<0 && rb.gravityScale>0){
            Flip();
        } else if(isFacingRight == true && dir>0 && rb.gravityScale<0){
            Flip();
        } else if(isFacingRight==false && dir<0 && rb.gravityScale<0){
            Flip();
        }
    }

    void Flip(){
        isFacingRight = !isFacingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}

