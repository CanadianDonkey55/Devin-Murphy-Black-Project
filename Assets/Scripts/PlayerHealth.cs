using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    [SerializeField] float basicEnemyDamage = 5f;
    [SerializeField] float bossEnemyDamage = 10f;
    [SerializeField] float bulletDamage = 7f;

    public Slider healthBar;

    private void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void TakeDamage(float damageTaken)
    {
        health = health - damageTaken;
        healthBar.value = health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BasicEnemy")
        {
            TakeDamage(basicEnemyDamage);
            if (health <= 0)
            {
                health = 0;
            }
        }
        if (collision.gameObject.tag == "BossEnemy")
        {
            TakeDamage(bossEnemyDamage);
            if (health <= 0)
            {
                health = 0;
            }
        }
        if (collision.gameObject.tag == "EnemyBullet")
        {
            TakeDamage(bulletDamage);
            if (health <= 0)
            {
                health = 0;
            }
        }
    }
}
