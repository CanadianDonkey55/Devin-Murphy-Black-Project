using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public float maxLifetime = 15;

    public string[] tags;

    public Vector3 enemyDirection;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, maxLifetime);
    }

    void Update()
    {
        Shoot(enemyDirection);
    }

    public void Shoot(Vector2 dir)
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < tags.Length; i++)
        {
            if (collision.gameObject.tag == tags[i])
            {
                Destroy(gameObject);
            }
        }
    }
}