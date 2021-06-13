using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject destroyEffect;
    public float health;
    public Flash flash;

    public void TakeDamage(float damageValue)
    {
        health -= damageValue;
        flash.FlashRed();


        if (health <= 0)
        {
            print(gameObject.name +"took a hit");
            Destroyer();
        }
    }

    void Destroyer()
    {
        print("destroy bullet");
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }



}
