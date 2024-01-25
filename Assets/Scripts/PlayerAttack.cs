using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletLocation;
    BulletMove move;
    public float bulletSpeed;

    GameObject FiredBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            var playerMovement = gameObject.GetComponent<PlayerMovement>();
            FiredBullet = Instantiate(bullet, bulletLocation.transform.position, playerMovement.bullet.transform.localRotation);
           // Vector3 dir = new Vector3(playerMovement.InputMax, playerMovement.InputMax);

            

           // FiredBullet.transform.localRotation = Quaternion.Euler(0, 0, 90);
            
            FiredBullet.GetComponent<BulletMove>().playerDirection = new Vector2(playerMovement.InputMax, 0);

           
        }
    }
}
