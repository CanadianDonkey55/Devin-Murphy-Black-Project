using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Enemy[] basicEnemies;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectsWithTag("BasicEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
