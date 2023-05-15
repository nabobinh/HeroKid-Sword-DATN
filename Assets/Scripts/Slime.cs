using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IDamageable

{
   Animator animator;
    
    Rigidbody2D rb;
    bool isAlive = true;
    public GameObject healthText;

    public float Health{
        set{
            
            if(value < health){
                animator.SetTrigger("hit");
                RectTransform textTransform = Instantiate(healthText).GetComponent<RectTransform>();
                textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                Canvas canvas = GameObject.FindObjectOfType<Canvas>();
                textTransform.SetParent(canvas.transform);
            }
            health = value;
            if(health<=0){
                animator.SetBool("isAlive",false);
                Targetable = false;
            }
        }
        get{
            return health;
        }
    }

    public bool Targetable{
        get{ 
            return targetable;
        }
        set{
            targetable = value;
            rb.simulated = value;
        }
    }
    public float health = 3f;
    public bool targetable = true;
    //Vật phẩm rớt từ slime
    public GameObject drop;

    private void Start(){
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);

        rb = GetComponent<Rigidbody2D>();
    }

    public void Defeated(){
        animator.SetTrigger("Defeated");
        
    }

    public void RemoveEnemy(){
        Destroy(gameObject);
        Instantiate(drop, transform.position, drop.transform.rotation); 
    }


    public void OnHit(float damage, Vector2 knockback){
        Health -= damage;
       rb.AddForce(knockback);
    }

    public void OnHit(float damage){
        Health -= damage;
    }


}
