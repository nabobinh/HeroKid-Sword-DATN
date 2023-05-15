using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    private Animator animator;
    private Transform target;
    public Transform homePos;

    
    [SerializeField]
    private float speed = 0.5f;
    [SerializeField]
    private float maxRange = 1.25f;
    [SerializeField]
    private float minRange = 0.25f;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = FindObjectOfType<playerController>().transform;
    } 

    void Update()
    {
        if(Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();  
        }
        else if(Vector3.Distance(target.position,transform.position) >= maxRange)
        {
            GoHome();
        }

    }

    public void FollowPlayer()
    {
        animator.SetBool("isMoving", true);
        animator.SetFloat("moveX", (target.position.x - transform.position.x));
        animator.SetFloat("moveY",(target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

    }

    public void GoHome()
    {
        animator.SetFloat("moveX", (homePos.position.x - transform.position.x));
        animator.SetFloat("moveY",(homePos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position,homePos.position,speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, homePos.position) == 0 )
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "MyWeapon")
        {
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y +  difference.y);
        }
    }
}
