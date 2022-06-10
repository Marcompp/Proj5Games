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
    [SerializeField]
    GameObject pl;
    [SerializeField]
    public bool isFacingRight = false;
    private Vector2 direcao;
    private float dirx;
    private float diry;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gm = GameManager.GetInstance();
        GetComponent<Rigidbody2D>().mass = 1*10^1000;
        pl = GameObject.FindGameObjectWithTag("Player");
        // Rigidbody cubeRigidbody = GetComponent<Rigidbody> ();
        // cubeRigidbody.isKinematic = false;
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
            dirx =  pl.transform.position.x - transform.position.x;
            if ((dirx <=5f && dirx >2f)||(dirx >=-5f && dirx <-2f)){
                anim.SetBool("attacking",false);
                anim.SetBool("running",true);
                Movement();
            }
            else if(dirx<=2f && dirx >=-2f){
                anim.SetBool("running",false);
                if(rb.gravityScale>0){
                    anim.SetBool("attacking",true);
                }
            }
            else{
                anim.SetBool("attacking",false);
                anim.SetBool("running",false);
            }

            diry = pl.transform.position.y - transform.position.y;
            if ((diry <=5f && diry >2f)||(diry >=-5f && diry <-2f)){
                anim.SetBool("attacking",false);
                anim.SetBool("running",true);
                Movement();
            }
            else if(diry<=2f && diry >=-2f){
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
        transform.Translate(Vector2.right*dirx * _speed * Time.deltaTime, Space.World);
        if(isFacingRight==false && dirx>0 && rb.gravityScale>0){
            Flip();
        } else if (isFacingRight == true && dirx<0 && rb.gravityScale>0){
            Flip();
        } else if(isFacingRight == true && dirx>0 && rb.gravityScale<0){
            Flip();
        } else if(isFacingRight==false && dirx<0 && rb.gravityScale<0){
            Flip();
        }
    }

    void Flip(){
        isFacingRight = !isFacingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;
        Scaler.y *= -1;
        transform.localScale = Scaler;
    }

}

