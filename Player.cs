using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private int health;
    public int maxHealth = 1;
    public Rigidbody2D rb;
    private Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
    }
     void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void Start()
    {
        health = maxHealth;
    }

    void ChangeHealth(int hpMod)
    {
        health += hpMod;
        if (health <= 0)
        {
            health = 0;
            Debug.Log("Player died");
        }
    }
}
