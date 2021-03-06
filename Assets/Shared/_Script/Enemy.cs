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
    SpriteRenderer renderer;
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
            dirx =  pl.transform.position.x - transform.position.x; //pega o valor do x do player e do inimigo
            diry = pl.transform.position.y - transform.position.y; //y é o eixo vertical
            if ((dirx <=3f && dirx >1.5f)||(dirx >=-3f && dirx <-1.5f)){
                
                anim.SetInteger("AnimState", 1);
                Movement();
            }
            else if(dirx<=1.5f && dirx >=-1.5f){
                anim.SetInteger("AnimState", 0);
                if(rb.gravityScale>0){
                    anim.SetTrigger("Attack1");
                }
            }
            else{
                anim.SetInteger("AnimState", 0);
            }

            if ((diry <=3f && diry >1.5f)||(diry >=-3f && diry <-1.5f)){
                anim.SetInteger("AnimState", 1);
            }
            else if(diry<=1.5f && diry >=-1.5f){
                anim.SetInteger("AnimState", 0);
                if(rb.gravityScale>0){
                    anim.SetTrigger("Attack1");
                }
            }
            else{
                anim.SetInteger("AnimState", 0);
            }
        }
        // if(Input.GetAxis("Horizontal")==0.0f){
        //     rb.velocity -= rb.velocity;
        // }
        
    }

    // void OnTriggerEnter2D(Object other) {
    //     if(other.name=="Main Character"){
    //         renderer= GetComponent<SpriteRenderer>();
    //         renderer.color = new Color(1,0,0);
    //         Invoke("LoseLife",0.5f);
    //     }
    // }

    // void LoseLife(){
        
    //     gm.hp --;
    //     if(gm.hp<=0){
    //         gm.ChangeState(GameManager.GameState.ENDGAME);
    //     }
    //     renderer.color = new Color(1,1,1);
    // }

    private void Movement()
    {
        rb.MovePosition(rb.position + new Vector2(dirx, diry).normalized   * _speed * Time.deltaTime);
        if(isFacingRight==false && dirx>0 ){
            Flip();
        } else if (isFacingRight == true && dirx<0 ){
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

