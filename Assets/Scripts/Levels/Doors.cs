using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public int enemyCount;

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("BasicEnemy").Length + GameObject.FindGameObjectsWithTag("RangedEnemy").Length;

        if (enemyCount == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
