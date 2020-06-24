using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed; 
    private Rigidbody2D rigidbody;
    public float jump;
    public LayerMask ground;
    private Collider2D playerCollider;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
        bool grounded = Physics2D.IsTouchingLayers(playerCollider,ground);
        animator.SetBool("grounded",grounded);  
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)){
            if(grounded)
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jump);
        }
        
    }
}
