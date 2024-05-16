using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pitfall : MonoBehaviour
{
    public float resetTimer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pitfall")
        {
            Debug.Log("hehehehaw");
            collision.gameObject.GetComponentInParent<Animator>().SetBool("falling", true);

            if (collision.gameObject.GetComponentInParent<PlayerHealth>().resettingScene == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
