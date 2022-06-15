using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public int attackDamage = 1;
    public float attackSpeed = 1f;
    private float attackFrames;
    private Transform target;
    [Header("Health")]
    private float health;
    public float shootingDistance;
    [SerializeField] private float maxHealth;

    [SerializeField] GameObject EnemyBulletPrefab;
    [SerializeField] Transform Gun;


    [SerializeField] float BulletSpeed = 7f;
    [SerializeField] float BulletDamage;
    [SerializeField] float GunBPS;
    float GunDelay;
    bool CanFire = true;

    void Update()
    {
        if (target != null)
        {

            float distance = Vector2.Distance(transform.position, target.transform.position);
            if (distance <= shootingDistance)
            {
                if (CanFire)
                {
                    Fire();
                } 
                else
                {
                    FireDelay();
                }
            } else
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            }
        }
    }


    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = null;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (attackSpeed <= attackFrames)
            {
                collision.gameObject.GetComponent<PlayerSettings>().ChangeHealth(-attackDamage);
                attackFrames = 0f;

                float offset = -90f;
                Vector2 _dir = target.position - transform.position;
                _dir.Normalize();
                float _angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
                Gun.rotation = Quaternion.Euler(new Vector3(0f, 0f, _angle + offset));

            } else
            {
                attackFrames += Time.deltaTime;
            }
        }
    }

    void Fire()
    {
        if (CanFire)
        {




            EnemyBullet bullet = Instantiate(EnemyBulletPrefab, Gun.position, Gun.rotation).GetComponent<EnemyBullet>();
            bullet.BulletVelocity = BulletSpeed;
            bullet.BulletDamage = BulletDamage;
            CanFire = false;
        }
    }
    void FireDelay()
    {
        if (GunDelay >= GunBPS)
        {
            GunDelay = 0f;
            CanFire = true;
        }
        else
        {
            GunDelay += Time.deltaTime;
        }
    }

}
