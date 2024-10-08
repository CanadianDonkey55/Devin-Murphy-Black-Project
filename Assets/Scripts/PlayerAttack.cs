using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    public ParticleSystem muzzleFlash;

    [Header("Bullet")]
    public GameObject bullet;
    public GameObject bulletLocation;
    BulletMove move;
    public float bulletSpeed;
    float reloadSpeed;
    [SerializeField] float startingReloadSpeed = 4;
    public bool isReloading = false;
    public float ammo = 20;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI reloadText;

    [Header("Shoot")]
    [SerializeField] float startingShootCooldown = 1.5f;
    float shootCooldown;
    public AudioSource shootSound;

    GameObject FiredBullet;

    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = startingShootCooldown;
        reloadSpeed = startingReloadSpeed;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButtonDown(0) && shootCooldown <= 0 && ammo > 0 && isReloading == false)
        {
            var playerMovement = gameObject.GetComponent<PlayerMovement>();
            FiredBullet = Instantiate(bullet, bulletLocation.transform.position, playerMovement.bullet.transform.localRotation);
            muzzleFlash.Play();
            shootSound.Play();
            FiredBullet.GetComponent<BulletMove>().playerDirection = new Vector2(playerMovement.InputMax, 0);
            ammo -= 1;
            ammoText.text = ammo + "/20";
            shootCooldown = startingShootCooldown;
        }
        if (ammo <= 0)
        {
            isReloading = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            isReloading = true;      
        }
        if (isReloading == true)
        {
            reloadText.enabled = true;
            int tempint = (int)reloadSpeed;
            reloadSpeed -= Time.deltaTime;       
            reloadText.text = "..." + tempint.ToString();
        }
        if (reloadSpeed <= 1)
        {
            ammo = 20;
            ammoText.text = ammo + "/20";
            reloadSpeed = startingReloadSpeed;
            isReloading = false;
            reloadText.enabled = false;
        }
        shootCooldown -= Time.deltaTime;
    }

}