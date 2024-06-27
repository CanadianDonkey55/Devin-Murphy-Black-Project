using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class MiniBoss : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] GameObject beam;

    public Slider healthBar;

    NavMeshAgent agent;

    public float health = 300;

    [Header("Distances")]
    private float locateDistance;
    public float locatedDistance = 10f;
    public float resetDistance = 5f;
    public float shootDistance = 5f;

    private Vector2 dir;

    [SerializeField] float shootCooldown = 2f;
    [SerializeField] float shootingCooldown = 6f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        locateDistance = resetDistance;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            health -= 5;
            healthBar.value = health;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void FollowPlayer()
    {
        float distance = (target.position - transform.position).magnitude;
        if (distance <= locateDistance)
        {
            if (distance > shootDistance || health > 150)
            {
                agent.SetDestination(target.position);
                locateDistance = locatedDistance;
            }
            else if (distance <= shootDistance && health < 150)
            {
                agent.SetDestination(transform.position);
                ShootPlayer();
            }
        }
        else
        {
            agent.SetDestination(transform.position);
            locateDistance = resetDistance;
        }
    }

    public void ShootPlayer()
    {
        if (shootCooldown > 0)
        {
            beam.SetActive(true);
            shootCooldown -= Time.deltaTime;
        }

        if (shootCooldown <= 0)
        {
            shootingCooldown -= Time.deltaTime;
        }

        if (shootingCooldown <= 0)
        {
            shootCooldown = 2f;
            shootingCooldown = 6f;
        }
    }

}
