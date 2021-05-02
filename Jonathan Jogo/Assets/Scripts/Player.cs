using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    public int speed;
    private int jump = 0;
    public bool doubleJump = false;
    private Animator anim;
    public float jumpHight;
    public int MaxLife;
    private int Life;

    void Start(){
        rig = GetComponent<Rigidbody2D>(); anim = GetComponent<Animator>();
        Life = MaxLife;
    }

    void Update(){
        Move(); 
        Jump();
    }

//     void move(){
//         Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
//         transform.position += movement * Time.deltaTime * speed;
//     }

    void Move(){
        Vector3 movement = new Vector2(Input.GetAxis("Horizontal"), 0f);
        rig.velocity = new Vector2(Input.GetAxis("Horizontal") * speed , rig.velocity[1]);
    }

    void Jump(){
        if(Input.GetButtonDown("Jump")){
            if((doubleJump && jump < 2) || (!doubleJump && jump < 1)){
                rig.velocity = new Vector2(rig.velocity[0], jumpHight);
                jump++;
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.layer == 6){
            jump = 0;
        }
    }

    void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.layer == 2){

        }
    }

    public void ResetLife(){
        Life = MaxLife;
    }

    public void TakeDamage(int Damage){
        Life -= Damage;
        if(Life <= 0)print("Game Over");
    }

    public void Heal(int Ammount){
        if(Life + Ammount >= MaxLife) ResetLife();
        else Life += Ammount;
    }
}
