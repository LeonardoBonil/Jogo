using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    public float Speed;
    public float JumpForce;
    public bool isJumping;
    private Animator anim;

    void Start()
    {rig = GetComponent<Rigidbody2D>(); anim = GetComponent<Animator>();}

    void Update(){Move(); Jump();}

    void Move(){
    if(Input.GetAxis("Horizontal") > 0f){anim.SetBool("Run", true); transform.eulerAngles = new Vector3(0f, 0f, 0f);}
    if(Input.GetAxis("Horizontal") < 0f){anim.SetBool("Run", true); transform.eulerAngles = new Vector3(0f, 180f, 0f);}
    if(Input.GetAxis("Horizontal") == 0f){anim.SetBool("Run", false);}
    Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); transform.position += movement * Time.deltaTime * Speed;}

   void Jump(){if(Input.GetButtonDown("Jump") && isJumping == false){rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse); anim.SetBool("Jump", true);}}
    
    void OnCollisionEnter2D(Collision2D collision){if(collision.gameObject.layer == 6 || collision.gameObject.layer == 7){isJumping = false; anim.SetBool("Jump", false);}}
    void OnCollisionExit2D(Collision2D collision){if(collision.gameObject.layer == 6 || collision.gameObject.layer == 7){isJumping = true;}}
}
