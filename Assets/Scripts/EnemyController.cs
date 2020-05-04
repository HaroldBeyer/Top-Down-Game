using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 startingPosition;
    private Vector3 roamPosition;
    public Transform player;
    private Rigidbody2D rigidbody;
    private Vector2 movement;
    public float moveSpeed = 5f;
    public int life = 5;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
        roamPosition = getRoamingPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkForPlayer())
        {

        }
        else
        {

        }
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rigidbody.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    private void LateUpdate()
    {
        if (life <= 0)
            Destroy(gameObject);
    }

    void moveCharacter(Vector2 direction)
    {
        rigidbody.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        print("damage!");
        if (other.gameObject.tag == "Bullet")
        {
            life--;
        }
    }

    private Vector3 getRoamingPosition()
    {
        return startingPosition + Utils.GetRandomDir() * Random.Range(10f, 70f);
    }

    private bool checkForPlayer()
    {
        // if (){
        //     return true
        // }
        return false;
    }

}

//posição inicial
//visão 360 graus
//visão seria interrompida por outros objetos
//ou seja, precisaria criar algo pra determinar isso
//
//
//
//
//
//
//
//
//