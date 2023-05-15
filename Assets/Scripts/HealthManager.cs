using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthManager : MonoBehaviour
{
    public int currentHealth = 100;
    public int maxHealth = 100;

    private bool flashActive;
    [SerializeField]
    private float flashLength = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer playerSprite;
    public playerController player;

    public static event Action OnPlayerdeath;

    [SerializeField] private AudioSource deathSoundEffect;

    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if(flashActive)
        {
            if(flashCounter > flashLength *.99f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b,0f);
            }
            else if(flashCounter > flashLength *.82f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b,1f);
            }
            else if(flashCounter > flashLength *.66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b,0f);
            }
            else if(flashCounter > flashLength *.49f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b,1f);
            }
            else if(flashCounter > flashLength *.33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b,0f);
            }
            else if(flashCounter > flashLength *.16f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b,1f);
            }
            else if(flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b,0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b,1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }

    public void HurtPlayer(int damageToGive)
    {
        currentHealth -= damageToGive;
        flashActive = true;
        flashCounter = flashLength; 
        if(currentHealth <= 0)
        {
              
            player.animator.SetBool("Death", true);
            deathSoundEffect.Play();

            OnPlayerdeath?.Invoke();
            //ameObject.SetActive(false); 

        }
    }
}
