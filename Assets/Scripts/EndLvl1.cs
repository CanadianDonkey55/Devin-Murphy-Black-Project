using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLvl1 : MonoBehaviour
{
    public GameObject LevelComplete;
    public ContinueLoader continueLoader; 

    // Start is called before the first frame update
    void Start()
    {
        LevelComplete.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LevelComplete.SetActive(true);
            continueLoader.lvl1Done = true;
        }
    }
}
