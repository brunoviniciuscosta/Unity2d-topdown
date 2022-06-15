using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    private float moveSpeed;
    private float SlashDamage = 10f;
    private float slashPS = 0.4f;
    private float attackFrames;
    private Transform target;
    [Header("Health")]
    private float health;
    private float maxHealth;
    private bool CanSlash = true;

    [SerializeField] Transform Hand;
    [SerializeField] Transform Sword;
    [SerializeField] GameObject EnemySwordSlashPreFab;

    private float slashDistance;




    void Update()
    {
        if (target != null)
        {
            float offset = -90f;
            Vector2 _dir = target.position - transform.position;
            _dir.Normalize();
            float _angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
            Hand.rotation = Quaternion.Euler(new Vector3(0f, 0f, _angle + offset));

            float distance = Vector2.Distance(transform.position, target.transform.position);
            if (distance <= slashDistance)
            {
                if (CanSlash)
                {
                    Slash();
                }
                else
                {
                    SlashDelay();
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            }
        }
    }


    private void Start()
    {
        health = maxHealth;
        switch (GameDifficulty.difficulty)
        {
            case GameDifficulty.Difficulties.Facil:
                moveSpeed = 3.5f;
                slashDistance = 0.8f;
                slashPS = 1f;
                break;
            case GameDifficulty.Difficulties.Medio:
                moveSpeed = 3.8f;
                slashDistance = 1f;
                slashPS = 0.8f;
                break;
            case GameDifficulty.Difficulties.Dificil:
                moveSpeed = 4f;
                slashDistance = 0.8f;
                slashPS = 0.6f;
                break;
            case GameDifficulty.Difficulties.Impossivel:
                moveSpeed = 5f;
                slashDistance = 0.8f;
                slashPS = 0.35f;
                break;
        }
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            Destroy(gameObject);
            Score.scoreValue += 10;
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

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        collision.gameObject.GetComponent<PlayerSettings>().ChangeHealth(-SlashDamage);
    //    }
    //}


    void SlashDelay()
    {
        if (attackFrames >= slashPS)
        {
            attackFrames = 0f;
            CanSlash = true;
        }
        else
        {
            attackFrames += Time.deltaTime;
        }
    }


    void Slash()
    {
        CanSlash = false;
        float angleSlash = AngleTowardsMouse(Hand.position);
        Quaternion rotationSlash = Quaternion.Euler(new Vector3(0f, 0f, angleSlash));

        EnemySlashScript enemySlash = Instantiate(EnemySwordSlashPreFab, Sword.position, rotationSlash).GetComponent<EnemySlashScript>();
        enemySlash.SlashDamage = SlashDamage;
    }



    public static float AngleTowardsMouse(Vector3 pos)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(pos);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        return angle;
    }
}
