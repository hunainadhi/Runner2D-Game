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

    public AudioSource deathSound;
    public AudioSource jumpSound;
    public float Milestone;
    private float MilestoneCount;
    public float speedMultiplier;

    public LayerMask deathGround;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        MilestoneCount = Milestone;
    }

    // Update is called once per frame
    void Update()
    {
        bool dead = Physics2D.IsTouchingLayers(playerCollider,deathGround);
        if(dead){
            GameOver();
        }

        if(transform.position.x > MilestoneCount){
            speed = speed * speedMultiplier;
            MilestoneCount+=Milestone;
            Milestone+=Milestone*speedMultiplier;
            Debug.Log("M"+Milestone+", "+"MC"+MilestoneCount+"MS"+speed);
        }
        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
        bool grounded = Physics2D.IsTouchingLayers(playerCollider,ground);
        animator.SetBool("grounded",grounded);  
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)){
            if(grounded){
                jumpSound.Play();   
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jump);
                
            }
        }
        
    }
    void GameOver(){
        gameManager.GameOver();
    }
}
