using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Animations;

public class Enemy : MonoBehaviour
{
    [SerializeField] AudioClip death;
    [SerializeField] Transform target;

    public Slider healthBar;

    NavMeshAgent agent;

    public float health = 20;

    [Header("Distances")]
    private float locateDistance;
    public float locatedDistance = 10f;
    public float resetDistance = 5f;

    private Vector2 dir;

    [Header("Animation stuff")]
    public float horizontalSpeed;
    public float verticalSpeed;
    public Animator enemyAnim;
   

    private new SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        locateDistance = resetDistance;
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //AudioSource.PlayClipAtPoint(death, transform.position, 1);
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
                AudioSource.PlayClipAtPoint(death, transform.position, 5);
                Debug.Log("die");
                Destroy(gameObject);
            }
        }
    }

    public void FollowPlayer()
    {
        float distance = (target.position - transform.position).magnitude;
        if (distance <= locateDistance)
        {
            agent.SetDestination(target.position);
            locateDistance = locatedDistance;
            dirRot();
        }
        else
        {
            agent.SetDestination(transform.position);
            locateDistance = resetDistance;
            enemyAnim.SetBool("walking", false);
        }
    }

    private void dirRot()
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
            }
            else if (m_Angle > 22.5 && m_Angle < 67.5)
            {
                
            }
            else if (m_Angle > 67.5 && m_Angle < 112.5)
            {
                enemyAnim.SetFloat("verticalSpeed", 1f);
                enemyAnim.SetFloat("horizontalSpeed", 0f);
                enemyAnim.SetBool("walking", true);
            }
            else if (m_Angle > 112.5 && m_Angle < 157.5)
            {
                
            }
            else if (m_Angle > 157.5 && m_Angle < 180)
            {
                enemyAnim.SetFloat("verticalSpeed", 0f);
                enemyAnim.SetFloat("horizontalSpeed", -1f);
                enemyAnim.SetBool("walking", true);
            }
        }

        else if (target.transform.position.y < transform.position.y)
        {
            if (m_Angle > 0 && m_Angle < 22.5)
            {
                enemyAnim.SetFloat("horizontalSpeed", 1f);
                enemyAnim.SetFloat("verticalSpeed", 0f);
                enemyAnim.SetBool("walking", true);
            }
            else if (m_Angle > 22.5 && m_Angle < 67.5)
            {
                
            }
            else if (m_Angle > 67.5 && m_Angle < 112.5)
            {
                enemyAnim.SetFloat("verticalSpeed", -1f);
                enemyAnim.SetFloat("horizontalSpeed", 0f);
                enemyAnim.SetBool("walking", true);
            }
            else if (m_Angle > 112.5 && m_Angle < 157.5)
            {
                
            }
            else if (m_Angle > 157.5 && m_Angle < 180)
            {
                enemyAnim.SetFloat("verticalSpeed", 0f);
                enemyAnim.SetFloat("horizontalSpeed", -1f);
                enemyAnim.SetBool("walking", true);
            }
        }
    }
}
