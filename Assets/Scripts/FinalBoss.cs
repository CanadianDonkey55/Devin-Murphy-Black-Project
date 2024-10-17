using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class FinalBoss : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] GameObject beam;
    [SerializeField] GameObject door;
    [SerializeField] ParticleSystem death;
    [SerializeField] BossDeathParticles particles;
    Animator anim;

    public Slider healthBar;

    NavMeshAgent agent;

    public float health = 300;

    [Header("Distances")]
    private float locateDistance;
    public float locatedDistance = 15f;
    public float resetDistance = 5f;
    public float shootDistance = 5f;

    private Vector2 dir;

    [SerializeField] float shootCooldown = 2f;
    [SerializeField] float shootingCooldown = 6f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        locateDistance = resetDistance;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        Debug.Log(shootCooldown);
        Debug.Log(shootingCooldown);
        dirRot();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            health -= 5;
            healthBar.value = health;
            if (health <= 0)
            {
                door.SetActive(false);
                death.Play(true);
                particles.bossDead = true;
                Destroy(gameObject);
            }
        }
    }

    public void FollowPlayer()
    {
        float distance = (target.position - transform.position).magnitude;

        if (distance <= locateDistance)
        {
            if (distance > shootDistance && health < health/2)
            {
                agent.SetDestination(transform.position);
                ShootPlayer();
            }
            else if (distance <= shootDistance || health > health/2)
            {
                agent.SetDestination(target.position);
                locateDistance = locatedDistance;
                beam.SetActive(false);
            }
        }
        else
        {
            agent.SetDestination(transform.position);
            locateDistance = resetDistance;
            beam.SetActive(false);
        }
    }

    public void ShootPlayer()
    {
        if (shootCooldown > 0)
        {
            beam.SetActive(true);
            shootCooldown -= Time.deltaTime;
            dir = (target.position - transform.position).normalized;
            dirRot();
        }

        if (shootCooldown <= 0)
        {
            beam.SetActive(false);
            shootingCooldown -= Time.deltaTime;
        }

        if (shootingCooldown <= 0)
        {
            shootCooldown = 2f;
            shootingCooldown = 6f;
        }
    }

    private void dirRot()
    {
        //GameObject bulletImage = bullet.transform.GetChild(0).gameObject;
        var distance = dir.magnitude;
        var direction = dir / distance;

        float m_Angle = Vector2.Angle(new Vector2(1, 0), direction);


        if (target.transform.position.y > transform.position.y)
        {
            if (m_Angle > 0 && m_Angle < 22.5)
            {
                beam.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (m_Angle > 22.5 && m_Angle < 67.5)
            {
                beam.transform.rotation = Quaternion.Euler(0, 0, 45);
            }
            else if (m_Angle > 67.5 && m_Angle < 112.5)
            {
                beam.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (m_Angle > 112.5 && m_Angle < 157.5)
            {
                beam.transform.rotation = Quaternion.Euler(0, 0, 135);
            }
            else if (m_Angle > 157.5 && m_Angle < 180)
            {
                beam.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }

        else if (target.transform.position.y < transform.position.y)
        {
            if (m_Angle > 0 && m_Angle < 22.5)
            {
                beam.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (m_Angle > 22.5 && m_Angle < 67.5)
            {
                beam.transform.rotation = Quaternion.Euler(0, 0, -45);
            }
            else if (m_Angle > 67.5 && m_Angle < 112.5)
            {
                beam.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else if (m_Angle > 112.5 && m_Angle < 157.5)
            {
                beam.transform.rotation = Quaternion.Euler(0, 0, -135);
            }
            else if (m_Angle > 157.5 && m_Angle < 180)
            {
                beam.transform.rotation = Quaternion.Euler(0, 0, -180);
            }
        }
    }
}