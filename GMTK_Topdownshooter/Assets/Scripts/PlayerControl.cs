using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float rotationSpeed = 10f;
    public float bulletForce = 5;
    public GameObject bulletPrefab;
    public Transform firePoint;

    Rigidbody2D rb;

    Vector2 rawInputMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            print("HALLO");
        }
        //context.performed
        //GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        //Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        //bulletRb.AddForce(Vector3.forward * bulletForce, ForceMode2D.Impulse);
        //print("HALLO");

    }

    

}
