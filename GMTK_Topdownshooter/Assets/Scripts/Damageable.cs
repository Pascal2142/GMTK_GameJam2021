using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public HealthBubble healthBubble;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotHit(int damage)
    {
        healthBubble.TakeDamage(damage);
        print("Auaaa!!!!");
    }
}
