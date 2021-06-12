using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform player;
    public float damage;

    public float moveSpeed = 5f;
    public float avoidSpeed = 10f;
    public float stoppingDistance = 20f;
    public float retreatDistance = 10f;
    public float minDistance = 10f;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

            Vector3 avoidDir = transform.position - collision.transform.position;
            avoidDir = avoidDir.normalized * minDistance;
            transform.position = Vector2.MoveTowards(transform.position, (transform.position + avoidDir), avoidSpeed * Time.fixedDeltaTime);

        }

        if (collision.tag == "Player")
        {
            //collider.isTrigger = false;
            Destroy(gameObject);
            print("Player hit");
            var damageable = collision.gameObject.GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.GotHit(10);
            }
        }
    }

   
  
    
    private void Move()
    {
        //Move toward the Player       
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.fixedDeltaTime);
        

        //Rotate to Player
        Vector2 lookDir = player.position - this.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        rb.rotation = angle;
    }
}


