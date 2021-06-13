using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject destroyEffect;
    public float dmg;
    public float lifeTime;



    private void Start()
    {
        //Invoke("Destroyer", lifeTime);
        //print("bullet TTL: " + lifeTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //collider.isTrigger = false;
            //Destroy(gameObject);
            print("Player hit");
            var damageable = collision.gameObject.GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.GotHit(dmg);
                Destroyer();
            }
        }
    }

    void Destroyer()
    {
        print("destroy bullet");
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
