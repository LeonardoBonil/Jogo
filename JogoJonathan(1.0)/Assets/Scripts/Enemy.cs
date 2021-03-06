using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	private Rigidbody2D rig;
	private Animator anim;
	public float speed;
	public bool colliding;
	public Transform leftCol;
	public Transform rightCol;
	public LayerMask layer;
	public BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
	anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
	colliding = Physics2D.Linecast(rightCol.position, leftCol.position);
	if(colliding){
	transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
	speed *= -1f;
      }
    }
}
