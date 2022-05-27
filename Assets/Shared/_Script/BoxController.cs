using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
 
    void Start()
    {
    }
 /*
    void FixedUpdate()
    {
        if (!isColliding)
        {
            position = GetComponent<Rigidbody2D>().position;
            velocity = GetComponent<Rigidbody2D>().velocity;
        }
    }
 
    void LateUpdate()
    {
        if (isColliding)
        {
            GetComponent<Rigidbody2D>().position = position;
            GetComponent<Rigidbody2D>().velocity = velocity;
        }
    }
 
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Box") {
            print(col.relativeVelocity);
            isColliding = true;
            }
    }*/

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
                /*print(col.relativeVelocity);
                GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);*/
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                GetComponent<Rigidbody2D>().mass = 5;
                GetComponent<Rigidbody2D>().drag = 10;

                /*
                if (col.relativeVelocity.x != 0) {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0,GetComponent<Rigidbody2D>().velocity.y);
                }
                if (col.relativeVelocity.y != 0) {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,0);
                }*/
                
            }
    }
    void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
                /*print(col.relativeVelocity);
                GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);*/
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
    }
 /*
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Box"){
            isColliding = false;
        }
    }*/

/*
    void OnCollisionEnter2D(Collision2D col)
    {
       if (col.gameObject.tag == "Box")
       {
           print(col.relativeVelocity);
           Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(),true);
       }
    }*/
    
}
