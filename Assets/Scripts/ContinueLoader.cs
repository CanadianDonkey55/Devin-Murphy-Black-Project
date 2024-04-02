using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueLoader : MonoBehaviour
{
    public int sceneNumber;
    public bool onLevel;
    public ContinueLoader sceneManagement;
    

    private void Awake()
    {
        if (onLevel == false)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        if (onLevel == true)
        {
            sceneNumber = SceneManager.GetActiveScene().buildIndex;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (onLevel == true)
        {
            ContinueLoader[] loaders; = FindObjectsOfType<ContinueLoader>();
            
        }
    }
}
