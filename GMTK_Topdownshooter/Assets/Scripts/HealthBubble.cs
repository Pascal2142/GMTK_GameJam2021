using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBubble : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;
    public Lerp lerpScale; 

    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
            
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        StartCoroutine(lerpScale.LerpFunction(0.5f, 2f));

    }

}
