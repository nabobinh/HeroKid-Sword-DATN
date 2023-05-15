using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHP : MonoBehaviour
{
    public HealthManager HP;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Heart"))
        {

            HP.currentHealth += 20 ;
            if(HP.currentHealth >100)
            {
                HP.currentHealth = 100;
            }
            Destroy(other.gameObject);
        }
    }
}
