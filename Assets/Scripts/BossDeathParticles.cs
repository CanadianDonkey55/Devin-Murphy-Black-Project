using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathParticles : MonoBehaviour
{
    public Transform boss;

    public bool bossDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bossDead == false)
        {
            transform.position = boss.position;
        } else
        {
            return;
        }
    }
}
