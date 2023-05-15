using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    
    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }



    public void Damage(float dm)
    {
        currentHealth -= dm;
        
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);    
    }
}
