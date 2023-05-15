using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive = 2;

    public float knockbackForce = 5000f;
    [SerializeField] private AudioSource atSoundEnemy;
    [SerializeField] private AudioSource atSoundSlime;

    public GameObject healthText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            atSoundEnemy.Play();
            EnemyHealthManager eHealthMan;
            eHealthMan = other.gameObject.GetComponent<EnemyHealthManager>();
            eHealthMan.HurtEnemy(damageToGive);
        }

        if(other.tag == "Slime"){
            IDamageable damageableObject = other.GetComponent<IDamageable>();
            atSoundSlime.Play();
            //Gây sát thương cho Slime
            if(damageableObject != null){
                Slime enemy = other.GetComponent<Slime>();
                //Calculate Direction between character and slime
                Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;

                Vector2 direction = (Vector2)(other.gameObject.transform.position - parentPosition).normalized;
                Vector2 knockback = direction * knockbackForce;
                damageableObject.OnHit(damageToGive,knockback);
            }
            else{
                Debug.LogWarning("Collider does not implement IDamageable");
            }
        }
    }

   
    
}
