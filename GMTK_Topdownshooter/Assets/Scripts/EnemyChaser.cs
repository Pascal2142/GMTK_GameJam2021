using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    public Rigidbody2D rb;
    //public Transform player;
    public float dmg;

    public GameObject[] player;
    public Transform target;

    public float moveSpeed = 5f;
    public float avoidSpeed = 10f;
    public float stoppingDistance = 20f;
    public float retreatDistance = 10f;
    public float minDistance = 10f;

    int randomTarget;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectsWithTag("Player");
        randomTarget = Random.Range(0, player.Length);
        //print(player.Length);
        target = player[randomTarget].transform;
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
                damageable.GotHit(dmg);
            }
        }
    }

   
  
    
    private void Move()
    {
        //Move toward the Player    
        var randomTarget = Random.Range(0, 2);
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
        

        //Rotate to Player
        Vector2 lookDir = target.position - this.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        rb.rotation = angle;
    }
}


