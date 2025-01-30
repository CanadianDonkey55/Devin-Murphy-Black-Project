using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueLoader : MonoBehaviour
{
    public int sceneNumber;
    public bool onLevel;
    public ContinueLoader sceneManagement;

    private static GameObject sampleInstance;

    [Header("Bools")]
    public bool[] lvlsDone = {false, false, false, false, false, false, false, false, false};

    private void Awake()
    {
        if (onLevel == false)
        {
            if (sampleInstance == null)
            {
                Destroy(sampleInstance);
            }
            sampleInstance = gameObject;
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
            for (int i = 0; i < lvlsDone.Length; i++)
            {
                if (lvlsDone[i])
                {
                    loaders.lvlsDone[i] = true;
                }
            }

        }

        if (onLevel == false)
        {
            ContinueLoader[] loaders = FindObjectsOfType<ContinueLoader>();
            foreach (ContinueLoader go in loaders)
            {
                if (go.gameObject != gameObject && lvlsDone[0] && go.onLevel == false)
                {
                    Destroy(go);
                }
                else
                {
                    return;
                }
            }      
        }
    }
}
