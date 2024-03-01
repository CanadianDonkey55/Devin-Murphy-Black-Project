using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Bullet")]
    public GameObject bullet;
    public GameObject bulletLocation;
    BulletMove move;
    public float bulletSpeed;

    [Header("Shoot")]
    [SerializeField] float startingShootCooldown = 1.5f;
    float shootCooldown;

    GameObject FiredBullet;

    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = startingShootCooldown;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButtonDown(0) && shootCooldown <= 0)
        {
            var playerMovement = gameObject.GetComponent<PlayerMovement>();
            FiredBullet = Instantiate(bullet, bulletLocation.transform.position, playerMovement.bullet.transform.localRotation);
            FiredBullet.GetComponent<BulletMove>().playerDirection = new Vector2(playerMovement.InputMax, 0);
            shootCooldown = startingShootCooldown;
        }
        shootCooldown -= Time.deltaTime;
    }
}
