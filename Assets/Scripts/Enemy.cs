using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;

    public Slider healthBar;

    NavMeshAgent agent;

    public float health = 20;

    [Header("Distances")]
    private float locateDistance;
    public float locatedDistance = 10f;
    public float resetDistance = 5f;

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
        if(collision.tag == "Bullet")
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
            agent.SetDestination(target.position);
            locateDistance = locatedDistance;
        }
        else
        {
            agent.SetDestination(transform.position);
            locateDistance = resetDistance;
        }
    }
}
