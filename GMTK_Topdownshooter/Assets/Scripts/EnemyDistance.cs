using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistance : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform target;
    public GameObject[] player;
    public float moveSpeed = 5f;
    public float avoidSpeed = 10f;
    public float stoppingDistance = 20f;
    public float retreatDistance = 10f;
    public float minDistance = 10f;
    int randomTarget;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectsWithTag("Player");
        randomTarget = Random.Range(0, player.Length);
        //print(player.Length);
        target = player[randomTarget].transform;
    }

    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    player = GameObject.FindGameObjectsWithTag("Player");

    //    if (player != null)
    //    {
    //        target[0] = player[0].transform;
    //        target[1] = player[1].transform;

    //        randomTarget = Random.Range(0, 2);
    //    }
    //}

    private void Update()
    {
        

       

    }
    private void FixedUpdate()
    {
        Move();
    }


    //Avoid other Enemys
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {

            Vector3 avoidDir = transform.position - collision.transform.position;
            avoidDir = avoidDir.normalized * minDistance;
            transform.position = Vector2.MoveTowards(transform.position, (transform.position + avoidDir), avoidSpeed * Time.fixedDeltaTime);
            //transform.Translate(avoidDir);
           // Transform tr = collision.transform;
            //tr.Translate(tr.position + new Vector3(1, 0, 0));
             //collision.rigidbody.MovePosition(collision.transform.position + new Vector3(2,3, 0));
            //collision.rigidbody.AddForce(Vector2.down * 50f);
         
        }
    }
  
    
    private void Move()
    {
        //Move according to Distances
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
        {
            
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -moveSpeed * Time.fixedDeltaTime);
           
        }

        //Rotate to Player
        Vector2 lookDir = this.transform.position - target.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        rb.rotation = angle;
    }
}


