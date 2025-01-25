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
            if (loader.lvl1Done)
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        } 
        else if (lvl3)
        {
            if (loader.lvl2Done)
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        }
        else if (lvl4)
        {
            if (loader.lvl3Done)
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        }
        else if (lvl5)
        {
            if (loader.lvl4Done)
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        }
        else if (lvl6)
        {
            if (loader.lvl5Done)
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        }
        else if (lvl7)
        {
            if (loader.lvl6Done)
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        }
        else if (lvl8)
        {
            if (loader.lvl7Done)
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        }
        else if (lvl9)
        {
            if (loader.lvl8Done)
            {
                gameObject.GetComponent<Button>().interactable = true;
            }
        }
        else if (lvl10)
        {
            if (loader.lvl9Done)
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
