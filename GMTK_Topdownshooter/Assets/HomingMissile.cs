using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public GameObject[] player;
    public Transform[] target;
    public float speed;
    public float turnSpeed;
    Rigidbody2D rb;

    int randomTarget;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectsWithTag("Player");
        target[0] = player[0].transform;
        target[1] = player[1].transform;

        randomTarget = Random.Range(0, 2);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector2 direction = rb.position - (Vector2)target[randomTarget].position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = rotateAmount * turnSpeed;
        rb.velocity = transform.up * speed;
    }
}
