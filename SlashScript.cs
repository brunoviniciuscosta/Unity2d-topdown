using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashScript : MonoBehaviour
{
    [HideInInspector] public float SlashDamage;

    private void Start()
    {
        Destroy(gameObject, 0.15f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyV2 enemy = collision.gameObject.GetComponent<EnemyV2>();
            enemy.TakeDamage(SlashDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "EnemyMelee")
        {
            EnemyMelee enemy = collision.gameObject.GetComponent<EnemyMelee>();
            enemy.TakeDamage(SlashDamage);
            Destroy(gameObject);
        }
    }
}
