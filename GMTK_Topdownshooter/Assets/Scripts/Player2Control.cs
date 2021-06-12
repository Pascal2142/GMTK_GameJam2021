using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Control : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float rotationSpeed = 10f;
    public float bulletForce;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public HealthBubble healthBubble;

    Rigidbody2D rb;

    Vector2 rawInputMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GotHit(20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + rawInputMovement * moveSpeed *Time.fixedDeltaTime);


        if (rawInputMovement != Vector2.zero)
        {
            Quaternion rotateTo = Quaternion.LookRotation(Vector3.forward, rawInputMovement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTo, rotationSpeed * Time.fixedDeltaTime);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 inputMovement = context.ReadValue<Vector2>();
        rawInputMovement = inputMovement;
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            Destroy(bullet, 2f);
            print("HALLO");
        }
    }

    public void GotHit(int damage)
    {
        healthBubble.TakeDamage(damage);
    }

}
