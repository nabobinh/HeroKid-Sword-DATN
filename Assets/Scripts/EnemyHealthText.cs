using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthText : MonoBehaviour
{
    private EnemyHealthManager ehm;
    public Slider healthBar;
    public Text hpText;

    // Start is called before the first frame update
    void Start()
    {
        ehm = FindObjectOfType<EnemyHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = ehm.maxHealth;
        healthBar.value = ehm.currentHealth;
        hpText.text =   ehm.currentHealth + "/" + ehm.maxHealth;
    }
}
