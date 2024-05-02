using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueLoader : MonoBehaviour
{
    public int sceneNumber;
    public bool onLevel;
    public ContinueLoader sceneManagement;

    [Header("Bools")]
    public bool lvl1Done = false;
    public bool lvl2Done = false;
    public bool lvl3Done = false;
    public bool lvl4Done = false;
    public bool lvl5Done = false;
    public bool lvl6Done = false;
    public bool lvl7Done = false;
    public bool lvl8Done = false;
    public bool lvl9Done = false;

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
            ContinueLoader loaders = FindObjectOfType<ContinueLoader>();
            loaders.sceneNumber = sceneNumber;
            
        }
    }
}
