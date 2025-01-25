using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathParticles : MonoBehaviour
{
    public Transform boss;

    public bool bossDead = false;

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
