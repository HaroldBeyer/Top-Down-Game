using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    public float moveSpeed = 5f;
    public Camera camera;
    public GameObject bloodEffect;
    Vector2 movement;
    Vector2 mousePos;
    public int life = 10;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidBody2D.MovePosition(rigidBody2D.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rigidBody2D.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rigidBody2D.rotation = angle;
    }

    private void LateUpdate()
    {
        if (life <= 0)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameObject effect = Instantiate(bloodEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.3f);
            life--;
        }

    }

}
