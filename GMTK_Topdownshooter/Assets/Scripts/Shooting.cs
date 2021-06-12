using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    private Transform target;

    private float timeBtwShots;
    public float shootCooldwon;
    public float bulletForce = 15;



    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = shootCooldwon;
    }


    void Update()
    {
        if (timeBtwShots <= 0)
        {
            timeBtwShots = shootCooldwon;
            Shoot();
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }


    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }

}
