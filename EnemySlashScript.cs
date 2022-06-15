using UnityEngine;

public class EnemySlashScript : MonoBehaviour
{
    [HideInInspector] public float SlashDamage;

    private void Start()
    {
        Destroy(gameObject, 0.3f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerSettings player = collision.gameObject.GetComponent<PlayerSettings>();
            player.ChangeHealth(SlashDamage);
        }
        Destroy(gameObject);
    }
}

