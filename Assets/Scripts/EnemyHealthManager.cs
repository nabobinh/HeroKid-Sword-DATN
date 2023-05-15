using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    private bool flashActive;
    [SerializeField]
    private float flashLength = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer enemySprite;

    public HealthbarBehaviour Healthbar;

    void Start()
    {
         enemySprite = GetComponent<SpriteRenderer>();
        Healthbar.SetHealth(currentHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(flashActive)
        {
            if(flashCounter > flashLength *.99f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b,0f);
            }
            else if(flashCounter > flashLength *.82f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b,1f);
            }
            else if(flashCounter > flashLength *.66f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b,0f);
            }
            else if(flashCounter > flashLength *.49f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b,1f);
            }
            else if(flashCounter > flashLength *.33f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b,0f);
            }
            else if(flashCounter > flashLength *.16f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b,1f);
            }
            else if(flashCounter > 0f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b,0f);
            }
            else
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b,1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }

    public GameObject drop;
    public GameObject drop2;
    public GameObject drop3;
    public void HurtEnemy(int damageToGive)
    {
        currentHealth -= damageToGive;
        flashActive = true;
        flashCounter = flashLength;
        Healthbar.SetHealth(currentHealth, maxHealth);
        //RectTransform Slider1 = Instantiate(Healthbar).GetComponent<RectTransform>();
       //Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
        //Slider1.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        //Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        //Slider1.SetParent(canvas.transform);
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(drop, transform.position, drop.transform.rotation);
            Instantiate(drop2, transform.position, drop2.transform.rotation);
            Instantiate(drop3, transform.position, drop3.transform.rotation);
        }
    }
}
