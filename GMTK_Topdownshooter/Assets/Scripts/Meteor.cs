using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float minMoveSpeed;
    public float maxMoveSpeed;
    public float dmg;
    public float minSpin;
    public float maxSpin;
    public float minSize;
    public float maxSize;
    Rigidbody2D rb;
    PolygonCollider2D collider;

    Vector3 randomDirection;
    // Start is called before the first frame update
    void Start()
    {
        var moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed + 1);
        rb = GetComponent<Rigidbody2D>();
        collider = gameObject.GetComponent<PolygonCollider2D>();
        collider.isTrigger = true;
        randomDirection = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
        rb.AddForce(transform.up + randomDirection * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);

        float spin = Random.Range(minSpin, maxSpin);
        rb.AddTorque(spin);

        float size = Random.Range(minSize, maxSize);
        transform.localScale = transform.localScale * size;
    }


    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(transform.up * moveSpeed, ForceMode2D.Impulse);
        //rb.MovePosition(transform.up * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        print("Hello");
        if (collision.tag == "Player")
        {
            //collider.isTrigger = false;
            Destroy(gameObject);
            print("Player hit");
            var damageable = collision.gameObject.GetComponent<Damageable>();
            if (damageable != null)
            {
                print("Kreis werd kleiner");
                damageable.GotHit(dmg);
            }
        }

        if (collision.tag != "PlayerBubble" && collision.tag != "Bullet" && collision.tag != "DestroyRunaways")
        {
            collider.isTrigger = false;
        }
    }
}
