using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet: MonoBehaviour
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
        if (collision.gameObject.tag == "Player")
        {
            PlayerSettings player = collision.gameObject.GetComponent<PlayerSettings>();
            player.ChangeHealth(BulletDamage);
        }
        Destroy(gameObject);
    }
}
