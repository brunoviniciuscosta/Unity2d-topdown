using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [HideInInspector] public float BulletVelocity;
    [HideInInspector] public float BulletDamage;
    [SerializeField] Rigidbody2D rb;

    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * BulletVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyV2 enemy = collision.gameObject.GetComponent<EnemyV2>();
            enemy.TakeDamage(BulletDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "EnemyMelee")
        {
            EnemyMelee enemy = collision.gameObject.GetComponent<EnemyMelee>();
            enemy.TakeDamage(BulletDamage);
            Destroy(gameObject);
        }
    }
}
