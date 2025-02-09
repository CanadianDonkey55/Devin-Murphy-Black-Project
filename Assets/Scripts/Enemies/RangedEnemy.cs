using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField] Transform target;

    public Slider healthBar;

    NavMeshAgent agent;

    public float health = 15;

    public float bulletSpeed = 20f;

    private AudioSource shootSound;

    GameObject FiredBullet;
    public GameObject bullet;
    public GameObject bulletLocation;
    public EnemyBulletMove move;

    [SerializeField] private float shootCooldown = 1f;
    [SerializeField] private GameObject shootAlert;

    [Header("Distances")]
    private float locateDistance;
    public float locatedDistance = 15f;
    public float resetDistance = 10f;
    public float shootDistance = 5f;

    private Vector2 dir;

    [Header("Animation stuff")]
    public float horizontalSpeed;
    public float verticalSpeed;
    public Animator enemyAnim;

    // Start is called before the first frame update
    void Start()
    {
        shootSound = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        locateDistance = resetDistance;
        shootAlert.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        Debug.Log(enemyAnim.GetBool("walking"));
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
            if (distance > shootDistance)
            {
                agent.SetDestination(target.position);
                locateDistance = locatedDistance;
                animDirRot();
            }
            else if (distance <= shootDistance)
            {
                agent.SetDestination(transform.position);
                ShootPlayer();
                enemyAnim.SetBool("walking", false);
            }
        }
        else 
        {
            agent.SetDestination(transform.position);
            locateDistance = resetDistance;
            enemyAnim.SetBool("walking", false);
        }
    }

    public void ShootPlayer()
    {
        if (shootCooldown <= 0.3f)
        {
            Debug.Log("Alert");
            shootAlert.SetActive(true);
        }

        if (shootCooldown <= 0)
        {
            shootSound.Play();
            FiredBullet = Instantiate(bullet, bulletLocation.transform.position, Quaternion.identity);
            dir = (target.position - transform.position).normalized;
            dirRot();    
            FiredBullet.GetComponentInChildren<EnemyBulletMove>().enemyDirection = new Vector2(dir.x, dir.y);
            shootAlert.SetActive(false);
            shootCooldown = 1;
        }

        shootCooldown -= Time.deltaTime;
    }

    private void animDirRot()
    {
        dir = (target.position - transform.position).normalized;
        var distance = dir.magnitude;
        var direction = dir / distance;

        float m_Angle = Vector2.Angle(new Vector2(1, 0), direction);

        if (target.transform.position.y > transform.position.y)
        {
            if (m_Angle > 0 && m_Angle < 22.5)
            {
                enemyAnim.SetFloat("horizontalSpeed", 1f);
                enemyAnim.SetFloat("verticalSpeed", 0f);
                enemyAnim.SetBool("walking", true);
                Debug.Log(enemyAnim.GetFloat("horizontalSpeed"));
            }
            else if (m_Angle > 67.5 && m_Angle < 112.5)
            {
                enemyAnim.SetFloat("verticalSpeed", 1f);
                enemyAnim.SetFloat("horizontalSpeed", 0f);
                enemyAnim.SetBool("walking", true);
                Debug.Log(enemyAnim.GetFloat("verticalSpeed"));
            }
            else if (m_Angle > 157.5 && m_Angle < 180)
            {
                enemyAnim.SetFloat("verticalSpeed", 0f);
                enemyAnim.SetFloat("horizontalSpeed", -1f);
                enemyAnim.SetBool("walking", true);
                Debug.Log(enemyAnim.GetFloat("horizontalSpeed"));
            }
        }

        else if (target.transform.position.y < transform.position.y)
        {
            if (m_Angle > 0 && m_Angle < 22.5)
            {
                enemyAnim.SetFloat("horizontalSpeed", 1f);
                enemyAnim.SetFloat("verticalSpeed", 0f);
                enemyAnim.SetBool("walking", true);
                Debug.Log(enemyAnim.GetFloat("horizontalSpeed"));
            }
            else if (m_Angle > 67.5 && m_Angle < 112.5)
            {
                enemyAnim.SetFloat("verticalSpeed", -1f);
                enemyAnim.SetFloat("horizontalSpeed", 0f);
                enemyAnim.SetBool("walking", true);
                Debug.Log(enemyAnim.GetFloat("verticalSpeed"));
            }
            else if (m_Angle > 157.5 && m_Angle < 180)
            {
                enemyAnim.SetFloat("verticalSpeed", 0f);
                enemyAnim.SetFloat("horizontalSpeed", -1f);
                enemyAnim.SetBool("walking", true);
                Debug.Log(enemyAnim.GetFloat("horizontalSpeed"));
            }
        }
    }

    private void dirRot()
    {
        var distance = dir.magnitude;
        var direction = dir / distance;

        float m_Angle = Vector2.Angle(new Vector2(1, 0), direction);


        if (target.transform.position.y > transform.position.y)
        {
            if (m_Angle > 0 && m_Angle < 22.5)
            {
                FiredBullet.transform.localRotation = Quaternion.Euler(0, 0, 0);
                dir.x = 1;
                dir.y = 0;
            }
            else if (m_Angle > 22.5 && m_Angle < 67.5)
            {
                dir.x = 1;
                dir.y = 1;
                FiredBullet.transform.localRotation = Quaternion.Euler(0, 0, 45);
            }
            else if (m_Angle > 67.5 && m_Angle < 112.5)
            {
                dir.x = 0;
                dir.y = 1;
                FiredBullet.transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            else if (m_Angle > 112.5 && m_Angle < 157.5)
            {
                dir.x = -1;
                dir.y = 1;
                FiredBullet.transform.localRotation = Quaternion.Euler(0, 0, 135);
            }
            else if (m_Angle > 157.5 && m_Angle < 180)
            {
                dir.x = -1;
                dir.y = 0;
                FiredBullet.transform.localRotation = Quaternion.Euler(0, 0, 180);
            }
        }

        else if (target.transform.position.y < transform.position.y)
        {
            if (m_Angle > 0 && m_Angle < 22.5)
            {
                FiredBullet.transform.localRotation = Quaternion.Euler(0, 0, 0);
                dir.x = 1;
                dir.y = 0;
            }
            else if (m_Angle > 22.5 && m_Angle < 67.5)
            {
                FiredBullet.transform.localRotation = Quaternion.Euler(0, 0, -45);
                dir.x = 1;
                dir.y = -1;
            }
            else if (m_Angle > 67.5 && m_Angle < 112.5)
            {
                FiredBullet.transform.localRotation = Quaternion.Euler(0, 0, -90);
                dir.x = 0;
                dir.y = -1;
            }
            else if (m_Angle > 112.5 && m_Angle < 157.5)
            {
                FiredBullet.transform.localRotation = Quaternion.Euler(0, 0, -135);
                dir.x = -1;
                dir.y = -1;
            } 
            else if (m_Angle > 157.5 && m_Angle < 180)
            {
                FiredBullet.transform.localRotation = Quaternion.Euler(0, 0, -180);
                dir.x = -1;
                dir.y = 0;
            }
        }
    }
}