using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public HealthBubble healthBubble;
    public Flash flash;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotHit(float damage)
    {
        print("Auaaa!!!!");
        flash.FlashRed();
        healthBubble.TakeDamage(damage);
    }
}
