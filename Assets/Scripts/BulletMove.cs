using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public float maxLifetime = 15;

    public string[] tags;

    public Vector3 playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Shoot(playerDirection);
    }

    public void Shoot(Vector2 dir)
    {
        transform.Translate(dir * bulletSpeed * Time.deltaTime);
        Destroy(gameObject, maxLifetime);
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
