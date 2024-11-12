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
    [SerializeField] float miniBossEnemyDamage = 7f;
    [SerializeField] float bulletDamage = 7f;
    [SerializeField] float lazerbeamDamage = 9f;

    public float damageTimer = 1f; 

    public Slider healthBar;
    public bool resettingScene;

    bool takingDamage = false;

    private void Update()
    {
        //Debug.Log(damageTimer);
        if (health <= 0)
        {
            SceneManager.LoadScene(1);
        }

        if (takingDamage == true)
        {
            damageTimer -= Time.deltaTime;
        }
    }

    private void TakeDamage(float damageTaken)
    {
        if (damageTimer == 1f && takingDamage == false)
        {
            takingDamage = true;
            health = health - damageTaken;
            healthBar.value = health;
        } 

        if (damageTimer <= 0)
        {
            takingDamage = false;
            damageTimer = 1;    
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        gameObject.transform.position = gameObject.transform.position += Vector3.one * 0.0001f;
        if (collision.gameObject.tag == "BasicEnemy")
        {
            TakeDamage(basicEnemyDamage);
            if (health <= 0)
            {
                health = 0;
            }
        }
        if (collision.gameObject.tag == "FinalBossEnemy")
        {
            TakeDamage(bossEnemyDamage);
            if (health <= 0)
            {
                health = 0;
            }
        }    
        if (collision.gameObject.tag == "MiniBossEnemy")
        {
            TakeDamage(miniBossEnemyDamage);
            if (health <= 0)
            {
                health = 0;
            }
        }
        if (collision.gameObject.tag == "Lazerbeam")
        {
            TakeDamage(lazerbeamDamage);
            if (health <= 0)
            {
                health = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Debug.Log("health");
            health = health - bulletDamage;
            healthBar.value = health;
            if (health <= 0)
            {
                health = 0;
            }
        }
    }



    public void ResetScene()
    {
        resettingScene = true;
    }
}
