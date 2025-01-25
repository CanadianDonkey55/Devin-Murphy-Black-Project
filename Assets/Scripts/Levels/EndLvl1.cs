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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LevelComplete.SetActive(true);
            if (continueLoader.sceneNumber == 2)
            {
                continueLoader.lvl1Done = true;
            }
            else if (continueLoader.sceneNumber == 3)
            {
                continueLoader.lvl2Done = true;
            } 
            else if (continueLoader.sceneNumber == 4)
            {
                continueLoader.lvl3Done = true;
            } 
            else if (continueLoader.sceneNumber == 5)
            {
                continueLoader.lvl4Done = true;
            } 
            else if (continueLoader.sceneNumber == 6)
            {
                continueLoader.lvl5Done = true;
            } 
            else if (continueLoader.sceneNumber == 7)
            {
                continueLoader.lvl6Done = true;
            } 
            else if (continueLoader.sceneNumber == 8)
            {
                continueLoader.lvl7Done = true;
            } 
            else if (continueLoader.sceneNumber == 9)
            {
                continueLoader.lvl8Done = true;
            } 
            else if (continueLoader.sceneNumber == 10)
            {
                continueLoader.lvl9Done = true;
            } 
        }
    }
}
