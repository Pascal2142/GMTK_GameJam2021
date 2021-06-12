using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float health;

    public void TakeDamage(float damageValue)
    {
        health -= damageValue;

        if (health <= 0)
        {
            print(gameObject.name +"took a hit");
            Destroy(gameObject);
        }
    }


}
