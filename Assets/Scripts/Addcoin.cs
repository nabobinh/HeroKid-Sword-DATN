using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Addcoin : MonoBehaviour
{
    public int playerScore = 0;

    public TextMeshProUGUI numbercoinText;
    [SerializeField] private AudioSource coinSoundEffect;


    public void AddScore()
    {
        playerScore += 50;
        numbercoinText.text = playerScore.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinSoundEffect.Play();
            Destroy(collision.gameObject);
            AddScore();
        }

    }
}
