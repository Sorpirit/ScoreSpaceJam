using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticle : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody objRb;


    private void Start()
    {
        objRb.velocity = Vector3.down * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Obsticle"))
        {
            Destroy(collision.gameObject);
            Die();
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
            health.Damage();
            Die();
        }

       
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
