using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMusic : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 1 && SceneManager.GetActiveScene().buildIndex < 12)
        {
            gameObject.GetComponent<AudioSource>().volume = 1;
        } else
        {
            gameObject.GetComponent<AudioSource>().volume = 0;
        }
    }
}
