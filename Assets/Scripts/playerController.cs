using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{

    private Rigidbody2D rb;
    public Animator animator;

    SpriteRenderer spriteRenderer;

    [SerializeField]
    private float speed = 150f;

    private float attackTime = .25f;
    private float attackCounter = .25f;
    private bool isAttacking;
    
    [SerializeField] private AudioSource atSoundEffect;
    [SerializeField] private AudioSource walkSoundEffect;

    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
         animator = GetComponent<Animator>();
         spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        walkSoundEffect.Play();
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"))*speed*Time.deltaTime;
        animator.SetFloat("moveX", rb.velocity.x);
        animator.SetFloat("moveY", rb.velocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Vertical") == 1 
        || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == -1)
        {
            
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }   
       
        if(isAttacking)
        {
            rb.velocity = Vector2.zero;
            attackCounter -= Time.deltaTime;
            if(attackCounter <= 0)
            {
                animator.SetBool("isAttacking",false);
                isAttacking = false;
            }
        }   

        if(Input.GetKeyDown(KeyCode.Space))
        {
            atSoundEffect.Play();
            attackCounter = attackTime;
            animator.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }

    public void FixedUpdate()
    {
        walkSoundEffect.Play();
        if(rb.velocity.x < 0){
                spriteRenderer.flipX = true;
               // gameObject.BroadcastMessage("IsFacingRight",false);
            }else if(rb.velocity.x > 0){
                spriteRenderer.flipX =false;
               // gameObject.BroadcastMessage("IsFacingRight",true);
            }


    }
}
