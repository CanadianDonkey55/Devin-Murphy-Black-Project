using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButtons : MonoBehaviour
{
    public bool lvl1 = false;
    public bool lvl2 = false;
    public bool lvl3 = false;
    public bool lvl4 = false;
    public bool lvl5 = false;
    public bool lvl6 = false;
    public bool lvl7 = false;
    public bool lvl8 = false;
    public bool lvl9 = false;
    public bool lvl10 = false;

    // Start is called before the first frame update
    void Start()
    {
        if (lvl1)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ContinueLoader loader = FindObjectOfType<ContinueLoader>();
        if (lvl1)
        {
            gameObject.GetComponent<Button>().interactable = true;
        } 
        else if (lvl2)
        {
            if (loader.lvlsDone[0])
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        } 
        else if (lvl3)
        {
            if (loader.lvlsDone[1])
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        }
        else if (lvl4)
        {
            if (loader.lvlsDone[2])
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        }
        else if (lvl5)
        {
            if (loader.lvlsDone[3])
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        }
        else if (lvl6)
        {
            if (loader.lvlsDone[4])
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        }
        else if (lvl7)
        {
            if (loader.lvlsDone[5])
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        }
        else if (lvl8)
        {
            if (loader.lvlsDone[6])
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        }
        else if (lvl9)
        {
            if (loader.lvlsDone[7])
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        }
        else if (lvl10)
        {
            if (loader.lvlsDone[8])
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            return;
        }
    }
}
