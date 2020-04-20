using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    public GameObject bloodEffect;
    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect;
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                effect = Instantiate(bloodEffect, transform.position, Quaternion.identity);
                Destroy(effect, 0.3f);
                break;
            default:
                effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 1f);
                break;
        }

        Destroy(gameObject);
    }
}
