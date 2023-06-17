using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    bool isJumping = false;

    private Rigidbody2D rig;
    Animator anim;

    private Vector2 initPosition;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        initPosition = new Vector2(-8, -2);  
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        //right
        if(Input.GetAxis("Horizontal") > 0f){
            anim.SetBool("run", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        //left
        if(Input.GetAxis("Horizontal") < 0f){
            anim.SetBool("run", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        //stop
        if(Input.GetAxis("Horizontal") == 0f){
            anim.SetBool("run", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }
   
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer == 8)
        {
            isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == 7 || col.gameObject.layer == 6)
        {
            GameManager.instance.LoseLife();
            transform.position = initPosition;
        }
    }
}